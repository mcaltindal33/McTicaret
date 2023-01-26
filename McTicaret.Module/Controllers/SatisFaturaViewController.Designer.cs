
namespace McTicaret.Module.Controllers
{
    partial class SatisFaturaViewController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UBLIncoiveCreate = new DevExpress.ExpressApp.Actions.SimpleAction(this.components);
            // 
            // UBLIncoiveCreate
            // 
            this.UBLIncoiveCreate.Caption = "e-Fatura Oluştur";
            this.UBLIncoiveCreate.ConfirmationMessage = null;
            this.UBLIncoiveCreate.Id = "UBLIncoiveCreate";
            this.UBLIncoiveCreate.ImageName = "Invoice";
            this.UBLIncoiveCreate.TargetObjectType = typeof(McTicaret.Module.BusinessObjects.SatisFaturasi);
            this.UBLIncoiveCreate.TargetViewType = DevExpress.ExpressApp.ViewType.DetailView;
            this.UBLIncoiveCreate.ToolTip = null;
            this.UBLIncoiveCreate.TypeOfView = typeof(DevExpress.ExpressApp.DetailView);
            this.UBLIncoiveCreate.Execute += new DevExpress.ExpressApp.Actions.SimpleActionExecuteEventHandler(this.UBLIncoiveCreate_Execute);
            // 
            // SatisFaturaViewController
            // 
            this.Actions.Add(this.UBLIncoiveCreate);

        }

        #endregion

        private DevExpress.ExpressApp.Actions.SimpleAction UBLIncoiveCreate;
    }
}
