using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using parking.Config;
using parking.Controllers;
using parking.DTO;
using parking.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace parking.Views.Administration.Configuration
{
    public partial class FrmBillRanges : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        Controllers.BillRangeController brc = new Controllers.BillRangeController();
        LogBookAppController lac= new LogBookAppController();
        BillController bc= new BillController();

        string establishment, emissionPoint, doctype, userId, moduleId = "RFAC";
        DateTime limitDate;
        int initialRange, finalRange, lastUsed;
        bool flagIsPaperbin = false,flagIsUpdate= false;
        public FrmBillRanges()
        {
            InitializeComponent();
        }

        private void PbxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmBillRanges_Load(object sender, EventArgs e)
        {
            startForm();
        }

        private void startForm()
        {
            getBillRanges("",false);
            flagIsUpdate = false;
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = PermissionManager.HasPermission(moduleId, "Crear");
            BtnDelete.Enabled = false;
            MskInitialRange.Enabled = false;
            MskFinalRange.Enabled = false;
            MskInitialRange.Clear();
            MskFinalRange.Clear();
            TxtBillRangeId.Clear();
            PbxDestroy.Visible = false;
            PbxRecovery.Visible = false;
            PbxDestroy.Enabled = false;
            PbxRecovery.Enabled = false;
            flagIsPaperbin = false;
            MskInitialRange.Focus();
            DtpLimitDate.Enabled = false;
            DtpLimitDate.Value= DateTime.Now;
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = true;
            MskInitialRange.Enabled = true;
            MskFinalRange.Enabled = true;
            MskInitialRange.Focus();
            DtpLimitDate.Enabled = true;

            TxtBillRangeId.Text = brc.getNextIdBillRange().ToString();
        }

        private void DgvBillRanges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvBillRanges.Rows.Count > 0)
            {
                BillRangeDTO billRange = brc.getBillRangeInfo(Convert.ToInt32(DgvBillRanges.CurrentRow.Cells[0].Value.ToString()));


                if (billRange == null)
                {
                    h.MsgError(Helpers.App.Msg0011);
                    return;
                }

                BtnNew.Enabled = false;
                BtnSave.Enabled = false;
                DtpLimitDate.Enabled = true;

                BtnDelete.Enabled = PermissionManager.HasPermission(moduleId, "Eliminar");
                BtnCancel.Enabled = true;
                BtnEdit.Enabled = flagIsPaperbin ? false : true;
                BtnDelete.Enabled = flagIsPaperbin ? false : true;

                if (billRange.BILL_RANGE_STATE == "ACTIVO")
                {
                    BtnEdit.Enabled = PermissionManager.HasPermission(moduleId, "Modificar");
                    MskInitialRange.Enabled = true;
                    MskFinalRange.Enabled = true;
                }
                else
                {
                    BtnEdit.Enabled = false;
                    MskInitialRange.Enabled = false;
                    MskFinalRange.Enabled = false;
                }

                MskInitialRange.Focus();
             
                PbxRecovery.Enabled = PermissionManager.HasPermission("PAP", "Modificar");
                PbxDestroy.Enabled = PermissionManager.HasPermission("PAP", "Eliminar");
                TxtBillRangeId.Text = billRange.BILL_RANGE_ID.ToString();
                MskInitialRange.Text = billRange.BILL_RANGE_START;
                MskFinalRange.Text = billRange.BILL_RANGE_END;
                DtpLimitDate.Value = billRange.LIMIT_DATE;
            }
        }

        private async void BtnEdit_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0002) == "S")
            {
                flagIsUpdate= true;
                if (validateData() == 0)
                {
                    setValues();
                    BILL_RANGE updateBillRange = brc.getBillRange(Convert.ToInt32(TxtBillRangeId.Text));

                    string cambios = "";
                    var separator = ", ";

                    if (updateBillRange.ESTABLISHMENT != establishment)
                        cambios += $"ESTABLISHMENT: '{updateBillRange.ESTABLISHMENT}' → '{establishment}'{separator}";

                    if (updateBillRange.EMISSION_POINT != emissionPoint)
                        cambios += $"EMISSION_POINT: '{updateBillRange.EMISSION_POINT}' → '{emissionPoint}'{separator}";

                    if (updateBillRange.DOC_TYPE != doctype)
                        cambios += $"DOC_TYPE: '{updateBillRange.DOC_TYPE}' → '{doctype}'{separator}";

                    if (updateBillRange.INITIAL_RANGE != initialRange)
                        cambios += $"INITIAL_RANGE: '{updateBillRange.INITIAL_RANGE}' → '{initialRange}'{separator}";

                    if (updateBillRange.FINAL_RANGE != finalRange)
                        cambios += $"FINAL_RANGE: '{updateBillRange.FINAL_RANGE}' → '{finalRange}'{separator}";

                    if(updateBillRange.LIMIT_DATE!=limitDate)
                        cambios += $"LIMIT_DATE: '{updateBillRange.LIMIT_DATE}' → '{limitDate}'{separator}";

                    // Limpiar coma final
                    if (!string.IsNullOrEmpty(cambios))
                        cambios = cambios.TrimEnd(',', ' ');

                    updateBillRange.ESTABLISHMENT = establishment;
                    updateBillRange.EMISSION_POINT = emissionPoint;
                    updateBillRange.DOC_TYPE = doctype;
                    updateBillRange.INITIAL_RANGE = initialRange;
                    updateBillRange.FINAL_RANGE = finalRange;
                    updateBillRange.LIMIT_DATE = limitDate;

                    if (brc.updateBillRange(updateBillRange) > 0)
                    {
                        if (!string.IsNullOrEmpty(cambios))
                        {
                            string logDesc = $"El usuario {Config.User.userName} modificó el rango de facturacion con código {updateBillRange.BILL_RANGE_ID}. Cambios: {cambios}.";
                            await lac.saveLog(Config.User.userId, "Modificar", logDesc, moduleId, DateTime.Now);
                        }
                        h.MsgInfo(Helpers.App.Msg0003);
                        startForm();
                    }
                    else
                    {
                        h.MsgError(Helpers.App.Msg0017);
                    }
                }

            }
        }

        private void BtnPaperbin_Click(object sender, EventArgs e)
        {
            startForm();
            BtnNew.Enabled = false;
            BtnCancel.Enabled = true;
            flagIsPaperbin = true;
            PbxDestroy.Visible = true;
            PbxRecovery.Visible = true;

            getBillRanges("",flagIsPaperbin);
        }

        private async void PbxRecovery_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0009) == "S")
            {
                BILL_RANGE br = brc.getBillRange(Convert.ToInt32(TxtBillRangeId.Text));
                br.DEL = false;

                if (br.LAST_USED < br.FINAL_RANGE)
                {
                    br.BILL_RANGE_STATE = true;
                }

                BILL_RANGE lastBillRange = brc.getBillRange(brc.getLastIdBillRange(false));

                
                if (brc.updateBillRange(br) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Recuperar", $"El usuario {Config.User.userName} restauró el rango de facturación con código  {brc.getLastIdBillRange(false)} de la papelera.", moduleId, DateTime.Now);

                    lastBillRange.BILL_RANGE_STATE = false;

                    if (brc.updateBillRange(lastBillRange) < 0)
                    {
                        h.MsgError(Helpers.App.Msg0017);
                        return;
                    }


                    h.MsgInfo(Helpers.App.Msg0010);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0019);
                }
            }

        }

        private async void PbxDestroy_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0007) == "S")
            {
                BILL_RANGE br = brc.getBillRange(Convert.ToInt32(TxtBillRangeId.Text));
                br.DEL = true;
                if (brc.deleteBillRange(br.BILL_RANGE_ID) > 0)
                {
                    BILL_RANGE lastBillRange= brc.getBillRange(brc.getLastIdBillRange(false));
                    await lac.saveLog(Config.User.userId, "Eliminar", $"El usuario {Config.User.userName} eliminó el rango de facturación con código  {TxtBillRangeId.Text}.", moduleId, DateTime.Now);

                    if (lastBillRange.LAST_USED < lastBillRange.FINAL_RANGE)
                    {
                        lastBillRange.BILL_RANGE_STATE = true;
                        if (brc.updateBillRange(lastBillRange) < 0)
                        {
                            h.MsgError(Helpers.App.Msg0016);
                            return;
                        }
                       
                    }
                    
                    h.MsgInfo(Helpers.App.Msg0008);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }


        }

        private void PbxSearch_Click(object sender, EventArgs e)
        {
            getBillRanges(TxtSearch.Text.Trim(), flagIsPaperbin);

        }

        private void PbxCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                getBillRanges(TxtSearch.Text.Trim(), flagIsPaperbin);
            }

        }

        private async void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion(Helpers.App.Msg0004) == "S")
            {
                BILL_RANGE br = brc.getBillRange(Convert.ToInt32(TxtBillRangeId.Text));
                br.DEL = true;
                if (brc.updateBillRange(br) > 0)
                {
                    await lac.saveLog(Config.User.userId, "Mover a papelera", $"El usuario {Config.User.userName} movió  el rango de facturación con código {br.BILL_RANGE_ID} a la papelera de reciclaje.", moduleId, DateTime.Now);

                   
                    BILL_RANGE lastBillRange = brc.getBillRange(brc.getLastIdBillRange(false));

                    if (lastBillRange.LAST_USED < lastBillRange.FINAL_RANGE)
                    {
                        lastBillRange.BILL_RANGE_STATE = true;
                        if (brc.updateBillRange(lastBillRange) < 0)
                        {
                            h.MsgError(Helpers.App.Msg0016);
                            return;
                        }

                    }

                    h.MsgInfo(Helpers.App.Msg0005);
                    startForm();
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0016);
                }
            }

        }

        public void getBillRanges(string searchFilter = "", bool isDel= false)
        {
            DgvBillRanges.Rows.Clear();
            IEnumerable<BillRangeDTO> billRanges = brc.getBillRanges(searchFilter,isDel);

            if (billRanges.Count() == 0)
            {
                h.MsgInfo(Helpers.App.Msg0012);

                if (searchFilter != "")
                {
                    getBillRanges("",isDel);
                    TxtSearch.Clear();
                }

                return;
            }

            foreach (var item in billRanges)
            {
                DgvBillRanges.Rows.Add(item.BILL_RANGE_ID, item.BILL_RANGE_START, item.BILL_RANGE_END, item.BILL_RANGE_STATE,Convert.ToDateTime(item.LIMIT_DATE).ToShortDateString() ,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }
        }

        private int validateData()
        {
            int error = 0;
            var lastBillRange = brc.getBillRangeInfo(brc.getLastIdBillRange(false));

            if (!MskInitialRange.MaskFull)
            {
                h.MsgWarning("DEBE INGRESAR EL RANGO INICIAL EN FORMATO CORRECTO.");
                MskInitialRange.Focus();
                error++;
                return error;
            }

            if (!MskFinalRange.MaskFull)
            {
                h.MsgWarning("DEBE INGRESAR EL RANGO FINAL EN FORMATO CORRECTO.");
                MskFinalRange.Focus();
                error++;
                return error;
            }

            if (!flagIsUpdate)
            {
                if (brc.existBillRange(MskInitialRange.Text, MskFinalRange.Text))
                {
                    h.MsgWarning("EL RANGO DE FACTURA YA EXISTE.");
                    error++;
                    return error;
                }
            }

            if (Convert.ToInt32(MskInitialRange.Text.Split('-')[3]) >= Convert.ToInt32(MskFinalRange.Text.Split('-')[3]))
            {
                h.MsgWarning("EL RANGO FINAL DEBE SER MAYOR AL RANGO INICIAL.");
                error++;
                return error;
            }


            if (lastBillRange.BILL_RANGE_ID != Convert.ToInt32(TxtBillRangeId.Text))
            {
                if (Convert.ToInt32(MskInitialRange.Text.Split('-')[3]) <= lastBillRange.FINAL_RANGE)
                {
                    h.MsgWarning("EL RANGO DE FACTURA INICIAL NO PUEDE SER MENOR O IGUAL QUE EL ÚLTIMO RANGO CONFIGURADO.");
                    error++;
                    return error;
                }
            }

            if (DtpLimitDate.Value < DateTime.Now)
            {
                h.MsgWarning("LA FECHA LIMITE NO DEBE SER MENOR A LA FECHA ACTUAL.");
                error++;
                return error;
            }
            return error;
        }


        private void setValues()
        {
            string[] billRange = MskInitialRange.Text.Split('-');
            establishment = billRange[0];
            emissionPoint = billRange[1];
            doctype = billRange[2];
            initialRange = Convert.ToInt32(billRange[3]);
            finalRange = Convert.ToInt32(MskFinalRange.Text.Split('-')[3]);
            limitDate = DtpLimitDate.Value;
            lastUsed = initialRange - 1;
            userId = Config.User.userId;


        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            if (validateData() == 0)
            {
                setValues();
                BILL_RANGE newBillRange = new BILL_RANGE();
                newBillRange.ESTABLISHMENT = establishment;
                newBillRange.EMISSION_POINT = emissionPoint;
                newBillRange.DOC_TYPE = doctype;
                newBillRange.INITIAL_RANGE = initialRange;
                newBillRange.FINAL_RANGE = finalRange;
                newBillRange.LAST_USED = lastUsed;
                newBillRange.INSERTED_AT = DateTime.Now;
                newBillRange.LIMIT_DATE = limitDate;
                newBillRange.BILL_RANGE_STATE = true;

                newBillRange.USER_CODE = userId;
                BILL_RANGE lastBillRange = brc.getBillRange(brc.getLastIdBillRange(false));

                if (brc.saveBillRange(newBillRange) > 0)
                {

                    lastBillRange.BILL_RANGE_STATE = false;

                    if (brc.updateBillRange(lastBillRange) > 0)
                    {
                        await lac.saveLog(Config.User.userId, "Insertar", $"El usuario {Config.User.userName} insertó el rango de facturación con código {brc.getLastIdBillRange(false)}.", moduleId, DateTime.Now);
                        
                        await lac.saveLog(Config.User.userId, "Modificar", $"El usuario {Config.User.userName} modificó el rango de facturacion con código {lastBillRange.BILL_RANGE_ID}. Cambios: BILL_RANGE_STATE: 'activo' → 'inactivo'.", moduleId, DateTime.Now);

                        h.MsgInfo(Helpers.App.Msg0001);
                        startForm();
                    }
                }
                else
                {
                    h.MsgError(Helpers.App.Msg0015);
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }
    }
}
