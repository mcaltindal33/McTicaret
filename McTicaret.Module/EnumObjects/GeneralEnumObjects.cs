using System;
using System.Linq;
using DevExpress.ExpressApp.DC;

namespace McTicaret.Module
{
    /// <summary>
    /// Taban - Fiyat değeri her malzeme için belirlenir ve saklanır.
    /// Dinamik - Fiyat değeri saklanmaz. Fiyat tipi uyguladığında taban fiyat üzerinde dinamik olarak hesaplanır.
    /// Hesaplanan - Fiyat değeri taban fiyat üzerinden hesaplanır ve saklanır.
    /// </summary>
    public enum FiyatTuru
    {
        [XafDisplayName("Taban Hesabı")]
        Taban ,
        [XafDisplayName("Dinamik Hesaplama")]
        Dinamik ,
        [XafDisplayName("Hesaplanan")]
        Hesaplanan
    }
    public enum ProjeOncelik
    {
        [XafDisplayName("Düşük")]
        Dusuk,
        [XafDisplayName("Normal")]
        Normal,
        [XafDisplayName("Yüksek")]
        Yuksek,
        [XafDisplayName("Kritik")]
        Kritik
    }
    public enum StokTuru
    {
        [XafDisplayName("Malzemeler")]
        Malzeme,
        [XafDisplayName("Hizmetler")]
        Hizmet
    }
    public enum EvrakTurleri
    {
        [XafDisplayName("Açılış Fişleri Fişi")]
        AcilisFisleri,
        [XafDisplayName("Alış Faturası Fişi")]// Bitti
        AlimFaturasi,
        [XafDisplayName("Alış İade Faturası Fişi")]//Bitti
        AlimIadeFaturasi,
        [XafDisplayName("Alış İrsaliyesi Fişi")] //Bitti
        AlimIrsaliye,
        [XafDisplayName("Alış İade İrsaliyesi Fişi")] //Bitti
        AlimIadeIrsaliye,
        [XafDisplayName("Alınan Teklif Fişi")] // Bitti
        AlinanTeklif,
        [XafDisplayName("Verilen Sipariş Fişi")] //Bitti
        VerilenSiparis,
        [XafDisplayName("Alınan Serbest Meslek Makbuzu Fişi")] //Bitti
        AlinanSerbestMeslekMakbuzu,
        [XafDisplayName("Gider Makbuzu Fişi")] //Sonra Yapılacak
        GiderMakbuzu,
        [XafDisplayName("Verilen Teklif Fişi")] //Bitti
        VerilenTeklif,
        [XafDisplayName("Alınan Sipariş Fişi")] //Bitti
        AlinanSiparis,
        [XafDisplayName("Satış Faturası Fişi")] //Bitti
        SatisFaturasi,
        [XafDisplayName("Satış İrsaliyesi Fişi")]// Bitti
        SatisIrsaliyesi,
        [XafDisplayName("Satış İade Faturası Fişi")] //Bitti
        SatisIadeFaturasi,
        [XafDisplayName("Satış İade İrsaliyesi Fişi")]//Bitti
        SatisIadeIrsaliyesi,
        [XafDisplayName("Verilen Serbest Meslek Makbuzu Fişi")] //Bitti
        VerilenSerbestMeslekMakbuzu,
        [XafDisplayName("Banka Havale/EFT Tahsilat Fişi")]//Bitti
        BankaHavaleEftTahsilat,
        [XafDisplayName("Kasa Tahsilat Fişi")] //Bitti
        KasaTahsilat,
        [XafDisplayName("Cari Hesap Çek/Senet Tahsilat  Fişi")]// Burası sonra yapılacak çeklerin ve senetlerin toplanacağı alan tasarlanması lazım.
        CariCekSenetTahsilat,
        [XafDisplayName("Banka Havale/EFT Ödeme Fişi")] //Bitti
        BankaHavaleEftOdeme,
        [XafDisplayName("Kasa Ödeme")] //Bitti
        KasaOdeme,
        [XafDisplayName("Cari Hesap Çek/Senet Ödeme Fişi")]// Burası sonra yapılacak çeklerin ve senetlerin toplanacağı alan tasarlanması lazım.
        CariCekSenetOdeme,
        [XafDisplayName("Kasadan Masraf Ödeme Fişi")]//Bitti
        KasadanMasrafOdeme,
        [XafDisplayName("Kasadan Personel Ödeme Fişi")]//Burası Sonra Yapılacak şuan için gerek yok
        KasadanPersonelOdeme,
        [XafDisplayName("Kasadan Bankaya Nakit Yatırma Fişi")] // Bitti
        KasadanBaknayaYatan,
        [XafDisplayName("Kasadan Kasaya Transfer Fişi")] //Bitti
        KasadanKasayaTransfer,
        [XafDisplayName("Kasadan Diğer Ödeme Fişi")]
        KasadanDigerNakitOdeme,
        [XafDisplayName("Bankadan Masraf Ödeme Fişi")]
        BankadanMasrafOdeme,
        [XafDisplayName("Bankadan Personel Ödeme Fişi")]// Burası Sonra yapılacak İşlem şuan için gerekli değil
        BankadanPersonelOdeme,
        [XafDisplayName("Bankadan Kasaya Nakit Çekme Fişi")] //Bitti
        BankadanKasayaCekilen,
        [XafDisplayName("Bankadan Diğer Ödeme Fişi")]
        BankadanDigerOdeme,
        [XafDisplayName("Bankadan Bankaya Transfer")] // Biti
        BankadanBankayaTransfer,
        [XafDisplayName("Cari Hesaplar")] // Biti
        CariHesap,
        [XafDisplayName("Bankalar")] // Biti
        Bankalar,
        [XafDisplayName("Banka Hesapları")] // Biti
        BankaHesaplari,
        [XafDisplayName("Banka Şubesi")] // Biti
        BankaSubesi,
        [XafDisplayName("Kasalar")] // Biti
        Kasalar,
        AdresTurleri
    }
    public enum MalzemeTipi
    {
        [XafDisplayName("1. Ticari Mallar")]
        TicariMal,
        [XafDisplayName("2. Tüketim Mallar")]
        TuketimMali,
        [XafDisplayName("3. Hammade")]
        Hammadde,
        [XafDisplayName("4. Üretim Ürün")]
        Urun,
        [XafDisplayName("5. Diğer")]
        Diger,
        [XafDisplayName("6. Kumaşlar")]
        Kumas,
        [XafDisplayName("7. Sünger")]
        Sunger
    }
    public enum IslemTurleri
    {
        Cikan = 1,
        Giren = 2,
        Irsaliye = 3,
        Teklif = 4,
        Transfer = 5,
        Diger = 6
    }
    public enum StokHareketTuru
    {
        StokCikisi,
        StokGirisi,
        TeklifSiparis,
    }
    public enum KasaHareketTuru
    {
        KasaCikisi,
        KasaGirisi
    }
    public enum BankaHareketTuru
    {
        BankaCikisi,
        BankaGirisi
    }
}
