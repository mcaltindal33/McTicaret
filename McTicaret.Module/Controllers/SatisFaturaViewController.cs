using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;

using McTicaret.Module.BusinessObjects;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace McTicaret.Module.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class SatisFaturaViewController : ViewController
    {
        public SatisFaturaViewController()
        {
            InitializeComponent();
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }

        private void UBLIncoiveCreate_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is SatisFaturasi eFatura)
            {
                CariHesapAdresler adresler = eFatura.Cari.Adresler.FirstOrDefault(x => x.Varsayilan == true);
                List<InvoiceLineType> lineTypes = new List<InvoiceLineType>();
                foreach (var item in eFatura.HareketDetay)
                {
                    var line = new InvoiceLineType
                    {
                        ID = new IDType { Value = item.Oid.ToString() },
                        Item = new ItemType
                        {
                            Name = new NameType1 { Value = item.Stok.Tanim }
                        },
                        Note = new[] { new NoteType { Value = $"{item.Stok.Kod} {item.Stok.Tanim}" } },
                        Price = new PriceType
                        {
                            PriceAmount = new PriceAmountType { Value = Convert.ToDecimal(item.BirimFiyat), currencyID = eFatura.Doviz.Kod }
                        },
                        InvoicedQuantity = new InvoicedQuantityType { Value = Convert.ToDecimal(item.Miktar), unitCode = "C62" },
                        LineExtensionAmount = new LineExtensionAmountType { Value = Convert.ToDecimal(item.IndirimsizTutar), currencyID = eFatura.Doviz.Kod },
                        AllowanceCharge = new[]
                        {
                            new AllowanceChargeType
                            {
                                ChargeIndicator = new ChargeIndicatorType { Value = false},
                                Amount = new AmountType2{Value = Convert.ToDecimal(item.IndirimTutar)},
                                MultiplierFactorNumeric = new MultiplierFactorNumericType{Value = Convert.ToDecimal(item.IndirimOran)},
                                 BaseAmount = new BaseAmountType{currencyID = eFatura.Doviz.Kod,Value = Convert.ToDecimal(item.IndirimsizTutar)}
                            }
                        },
                        TaxTotal = new TaxTotalType
                        {
                            TaxAmount = new TaxAmountType { Value = Convert.ToDecimal(item.KDVTutar), currencyID=eFatura.Doviz.Kod },
                            TaxSubtotal = new[]
                            {
                                new TaxSubtotalType
                                {
                                    TaxableAmount = new TaxableAmountType{Value=Convert.ToDecimal(item.NetTutar),currencyID=eFatura.Doviz.Kod },
                                    TaxAmount = new TaxAmountType{ Value = Convert.ToDecimal(item.KDVTutar),currencyID=eFatura.Doviz.Kod },
                                    CalculationSequenceNumeric = new CalculationSequenceNumericType{Value = 1},
                                    Percent = new PercentType1{Value = Convert.ToDecimal(item.KDVOrani)},
                                    TaxCategory = new TaxCategoryType
                                    {
                                        TaxScheme = new TaxSchemeType
                                        {
                                            TaxTypeCode = new TaxTypeCodeType {Value = "0015" ,name = "KDV"},
                                            Name = new NameType1{Value = "KDV"}
                                        }
                                    }
                                }
                            }
                        }
                    };
                    lineTypes.Add(line);
                }
                var invoice = new InvoiceType
                {
                    UBLVersionID = new UBLVersionIDType { Value = "2.1" },
                    CustomizationID = new CustomizationIDType { Value = "TR1.2" },
                    ProfileID = new ProfileIDType { Value = "TEMELFATURA" },
                    ID = new IDType { Value = eFatura.Kod },
                    CopyIndicator = new CopyIndicatorType { Value = false },
                    UUID = new UUIDType { Value = eFatura.Oid.ToString() },
                    IssueDate = new IssueDateType { Value = eFatura.Tarih },
                    IssueTime = new IssueTimeType { Value = eFatura.Tarih },
                    InvoiceTypeCode = new InvoiceTypeCodeType { Value = "SATIS" },
                    Note = new[]
                    {
                        //new NoteType { Value = eFatura.GenelToplam.YaziIleTutar() },
                        new NoteType { Value = eFatura.Aciklama }
                    },
                    DocumentCurrencyCode = new DocumentCurrencyCodeType { Value = eFatura.Doviz.Kod },
                    LineCountNumeric = new LineCountNumericType { Value = eFatura.HareketDetay.Count },
                    AdditionalDocumentReference = new[]
                    {
                        new DocumentReferenceType
                            {
                                ID = new IDType{Value=eFatura.Oid.ToString()},
                                IssueDate = new IssueDateType{Value = eFatura.Tarih},
                                DocumentType = new DocumentTypeType{Value="XSLT"},
                                Attachment = new AttachmentType
                                {
                                      EmbeddedDocumentBinaryObject = new EmbeddedDocumentBinaryObjectType
                                      {
                                            characterSetCode ="UTF-8",
                                            encodingCode = "Base64",
                                            filename = $"{eFatura.Kod}.xslt",
                                            mimeCode = "application/xml",
                                            Value = Encoding.UTF8.GetBytes(new StreamReader(new FileStream(@"C:\Users\PetroDATA\source\repos\McTicaret\McTicaret.Win\bin\Debug\general.xslt",FileMode.Open,FileAccess.Read),Encoding.UTF8).ReadToEnd())
                                      }
                                }
                            },
                        new DocumentReferenceType
                            {
                                 ID = new IDType{Value=eFatura.Oid.ToString()},
                                 IssueDate = new IssueDateType{Value = eFatura.Tarih},
                                 DocumentTypeCode = new DocumentTypeCodeType{Value="SendingType"},
                                 DocumentType = new DocumentTypeType{Value="ELEKTRONİK"}
                            }
                    },
                    Signature = new[]
                    {
                        new SignatureType
                        {
                            ID = new IDType { schemeID = "VKN_TCKN", Value = "54505654374" },
                            SignatoryParty = new PartyType
                            {
                                PartyIdentification = new []{new PartyIdentificationType { ID = new IDType { schemeID="VKN",Value="7290569093"} } },
                                PostalAddress = new AddressType
                                {
                                    Room = new RoomType{Value="19"},
                                    BlockName = new BlockNameType{Value="53/13"},
                                    CityName = new CityNameType{Value="Ankara"},
                                    CitySubdivisionName = new CitySubdivisionNameType{Value="Mamak"},
                                    BuildingName= new BuildingNameType{Value="Toki Toplu Kontular"},
                                    BuildingNumber = new BuildingNumberType{Value="53"},
                                    District = new DistrictType{Value="Mamak"},
                                    Region = new RegionType{Value="Zirvekent Mh."},
                                    StreetName = new StreetNameType{Value ="Osmanlı Cad."},
                                    Country = new CountryType{Name = new NameType1{Value="Türkiye"}}
                                }
                            },
                            DigitalSignatureAttachment = new AttachmentType{ ExternalReference = new ExternalReferenceType
                                                                                         {URI= new URIType{Value="#Signature_"+eFatura.BelgeNo} } }
                        }
                    },
                    AccountingSupplierParty = new SupplierPartyType
                    {
                        Party = new PartyType
                        {
                            PartyIdentification = new PartyIdentificationType[]
                            {
                                new PartyIdentificationType
                                {
                                    ID = new IDType
                                    {
                                        schemeID = "VKN",
                                        Value= "7290569093"
                                    }
                                },
                                new PartyIdentificationType
                                {
                                    ID = new IDType
                                    {
                                        schemeID = "MERSISNO",
                                        Value= "7290569093123456"
                                    }
                                }
                            },
                            PostalAddress = new AddressType
                            {
                                Room = new RoomType { Value = "19" },
                                BlockName = new BlockNameType { Value = "53/13" },
                                CityName = new CityNameType { Value = "Ankara" },
                                CitySubdivisionName = new CitySubdivisionNameType { Value = "Mamak" },
                                BuildingName = new BuildingNameType { Value = "Toki Toplu Kontular" },
                                BuildingNumber = new BuildingNumberType { Value = "53" },
                                District = new DistrictType { Value = "Mamak" },
                                Region = new RegionType { Value = "Zirvekent Mh." },
                                StreetName = new StreetNameType { Value = "Osmanlı Cad." },
                                Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                            },
                            PartyName = new PartyNameType { Name = new NameType1 { Value = "PETRODATA BİLİŞM DANIŞMANLIK EĞİTİM ELEKTRONİK SAN. VE TİC. LTD. ŞTİ." } },
                            WebsiteURI = new WebsiteURIType { Value = "petrodata.com.tr" },
                            Contact = new ContactType { Telephone = new TelephoneType { Value = "0545 955 85 50" }, ElectronicMail = new ElectronicMailType { Value = "mclatindal@petrodata.com.tr" } },
                            PartyTaxScheme = new PartyTaxSchemeType { TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = "DİKİMEVİ V.D." } } }
                        }
                    },
                    AccountingCustomerParty = new CustomerPartyType
                    {
                        Party = new PartyType
                        {
                            PartyIdentification = new[] { new PartyIdentificationType { ID = new IDType { schemeName = "VKN", Value = eFatura.Cari.VergiNo } } },
                            PartyName = new PartyNameType { Name = new NameType1 { Value = eFatura.Cari.Tanim } },
                            PartyTaxScheme = new PartyTaxSchemeType { TaxScheme = new TaxSchemeType { Name = new NameType1 { Value = eFatura.Cari.VergiDaire.Tanim } } },
                            PostalAddress = new AddressType
                            {
                                Room = new RoomType { Value = "19" },
                                BlockName = new BlockNameType { Value = "53/13" },
                                CityName = new CityNameType { Value = "Ankara" },
                                CitySubdivisionName = new CitySubdivisionNameType { Value = "Mamak" },
                                BuildingName = new BuildingNameType { Value = "Toki Toplu Kontular" },
                                BuildingNumber = new BuildingNumberType { Value = "53" },
                                District = new DistrictType { Value = "Mamak" },
                                Region = new RegionType { Value = "Zirvekent Mh." },
                                StreetName = new StreetNameType { Value = "Osmanlı Cad." },
                                Country = new CountryType { Name = new NameType1 { Value = "Türkiye" } }
                            },
                        }
                    },
                    TaxTotal = new[]
                    {
                        new TaxTotalType
                        {
                            TaxAmount = new TaxAmountType{Value = Convert.ToDecimal(eFatura.KdvToplam),currencyID=eFatura.Doviz.Kod},
                            TaxSubtotal = new[]
                            {
                                new TaxSubtotalType
                                {
                                    TaxableAmount = new TaxableAmountType{currencyID=eFatura.Doviz.Kod,Value=Convert.ToDecimal(eFatura.AltToplam)},
                                    TaxAmount = new TaxAmountType { Value= Convert.ToDecimal(eFatura.KdvToplam),currencyID=eFatura.Doviz.Kod},
                                    CalculationSequenceNumeric = new CalculationSequenceNumericType{Value=1},
                                    TransactionCurrencyTaxAmount = new TransactionCurrencyTaxAmountType{Value = Convert.ToDecimal(eFatura.KdvToplam),currencyID=eFatura.Doviz.Kod},
                                    TaxCategory = new TaxCategoryType
                                    {
                                        TaxScheme = new TaxSchemeType
                                        {
                                            Name = new NameType1{Value = "KDV"},
                                            TaxTypeCode = new TaxTypeCodeType{ Value ="0015"}
                                        }
                                    }

                                }
                            }
                        }
                    },
                    LegalMonetaryTotal = new MonetaryTotalType
                    {
                        LineExtensionAmount = new LineExtensionAmountType { Value = Convert.ToDecimal(eFatura.AltToplam), currencyID = eFatura.Doviz.Kod },
                        TaxExclusiveAmount = new TaxExclusiveAmountType { Value = Convert.ToDecimal(eFatura.HareketDetay.Sum(x => x.NetTutar)), currencyID = eFatura.Doviz.Kod },
                        TaxInclusiveAmount = new TaxInclusiveAmountType { Value = Convert.ToDecimal(eFatura.GenelToplam), currencyID = eFatura.Doviz.Kod },
                        AllowanceTotalAmount = new AllowanceTotalAmountType { Value = Convert.ToDecimal(eFatura.IndirimToplam), currencyID = eFatura.Doviz.Kod },
                        PayableAmount = new PayableAmountType { Value = Convert.ToDecimal(eFatura.GenelToplam), currencyID = eFatura.Doviz.Kod }

                    },
                    InvoiceLine = lineTypes.ToArray()
                };

                var settings = new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true };
                var ms = new MemoryStream();
                var writer = XmlWriter.Create(ms, settings);
                var xml = new XmlSerializer(invoice.GetType());
                xml.Serialize(writer, invoice, xmlNamespaces());
                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                var srRead = new StreamReader(ms);
                var readXml = srRead.ReadToEnd();
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EFatura", $"{invoice.ID.Value}.xml");


                if (!Directory.Exists($@"{AppDomain.CurrentDomain.BaseDirectory}\EFatura"))
                {
                    Directory.CreateDirectory($@"{AppDomain.CurrentDomain.BaseDirectory}\EFatura");
                }

                using (var wrin = new StreamWriter(path, false, Encoding.UTF8))
                {
                    wrin.Write(readXml);
                    wrin.Close();
                }

                XmlSerializerNamespaces xmlNamespaces()
                {
                    var ns = new    XmlSerializerNamespaces();
                    ns.Add("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
                    ns.Add("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                    ns.Add("xades", "http://uri.etsi.org/01903/v1.3.2#");
                    ns.Add("udt", "urn:un:unece:uncefact:data:specification:UnqualifiedDataTypesSchemaModule:2");
                    ns.Add("ccts", "urn:un:unece:uncefact:documentation:2");
                    ns.Add("ubltr", "urn:oasis:names:specification:ubl:schema:xsd:TurkishCustomizationExtensionComponents");
                    ns.Add("qdt", "urn:oasis:names:specification:ubl:schema:xsd:QualifiedDatatypes-2");
                    ns.Add("ext", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                    ns.Add("ds", "http://www.w3.org/2000/09/xmldsig#");
                    ns.Add("ef", "http://www.efatura.gov.tr/package-namespace");
                    ns.Add("sh", "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader");
                    ns.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
                    ns.Add("sch", "http://purl.oclc.org/dsdl/schematron");
                    ns.Add("urn", "urn:oasis:names:specification:ubl:schema:xsd:ApplicationResponse-2");
                    ns.Add("urn1", "urn:oasis:names:specification:ubl:schema:xsd:CommonExtensionComponents-2");
                    ns.Add("urn2", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
                    return ns;
                }

            }
        }
    }
}
