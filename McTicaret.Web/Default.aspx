<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" EnableViewState="false"
    ValidateRequest="false" CodeBehind="Default.aspx.cs" %>

<%@ Register Assembly="DevExpress.ExpressApp.Web.v20.2, Version=20.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.ExpressApp.Web.Templates" TagPrefix="cc3" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v20.2, Version=20.2.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.ExpressApp.Web.Controls" TagPrefix="cc4" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Main Page</title>
    <meta http-equiv="Expires" content="0" />
    <link href="manifest.json" rel="manifest" />
    <meta name="viewport" content="user-scalable=0, width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <style>
        @media (max-width: 700px) {
            #Vertical_LogoLink {
                display: none;
            }


            .paddings {
                padding-left: 0px;
                padding-right: 0px;
            }
        }

        .LayoutTabbedGroupContainer > .dxtc-stripContainer .dxtc-activeTab,
        .LayoutTabbedGroupContainer .dxtc-noSpacing > .dxtc-stripContainer .dxtc-activeTab.dxtc-lead,
        .LayoutTabbedGroupContainer .dxtc-noSpacing > .dxtc-stripContainer .dxtc-activeTab {
            background-color: #2c86d3 !important;
        }

        .LayoutTabbedGroupContainer .dxtcLite_XafTheme > .dxtc-stripContainer .dxtc-activeTab .dxtc-link {
            color: white;
        }

        .LayoutTabbedGroupContainer .dxtcLite_XafTheme > .dxtc-stripContainer .dxtc-tab,
        .LayoutTabbedGroupContainer .dxtcLite_XafTheme > .dxtc-stripContainer .dxtc-activeTab {
            background-color: PowderBlue;
        }

        .LayoutTabbedGroupContainer .dxtcLite_XafTheme > .dxtc-stripContainer .dxtc-tabHover,
        .LayoutTabbedGroupContainer .dxtcLite_XafTheme > .dxtc-stripContainer .dxtc-tabHover .dxtc-link {
            background-color: PowderBlue;
        }

        .menuAreaDiv .menuButtons .dxm-item.NewActionStyle,
        .menuLinks .dxm-item.NewActionStyle,
        .menuButtons .dxm-item.NewActionStyle a.dx {
            background-color: SkyBlue;
        }
    </style>
</head>
<body class="VerticalTemplate">
    <form id="form2" runat="server">
        <cc4:ASPxProgressControl ID="ProgressControl" runat="server" />
        <div runat="server" id="Content" />
    </form>
    <script>navigator.serviceWorker.register('service-worker.js');</script>
</body>
</html>
