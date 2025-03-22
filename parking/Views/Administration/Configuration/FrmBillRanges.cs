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

namespace parking.Views.Administration.Configuration
{
    public partial class FrmBillRanges : Form
    {
        Helpers.Helpers h = new Helpers.Helpers();
        Controllers.BillRangeController brc = new Controllers.BillRangeController();
        string establishment, emissionPoint, doctype, userId;
        int initialRange, finalRange,lastUsed;
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
            getBillRanges();
            BtnCancel.Enabled = false;
            BtnSave.Enabled = false;
            BtnEdit.Enabled = false;
            BtnNew.Enabled = true;
            BtnDelete.Enabled = false;
            MskInitialRange.Enabled = false;
            MskFinalRange.Enabled = false;
            MskInitialRange.Clear();
            MskFinalRange.Clear();
            TxtBillRangeId.Clear();

            MskInitialRange.Focus();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            BtnCancel.Enabled = true;
            BtnNew.Enabled = false;
            BtnSave.Enabled = true;
            MskInitialRange.Enabled = true;
            MskFinalRange.Enabled = true;
            MskInitialRange.Focus();

            TxtBillRangeId.Text = brc.getNextIdBillRange().ToString();
        }

        private void DgvBillRanges_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvBillRanges.Rows.Count > 0)
            {
                var billRange = brc.getBillRangeInfo(Convert.ToInt32(DgvBillRanges.CurrentRow.Cells[0].Value.ToString()));

                

                BtnNew.Enabled = false;
                BtnSave.Enabled = false;
               
                BtnDelete.Enabled = true;
                BtnCancel.Enabled = true;

                if(billRange.BILL_RANGE_STATE == "ACTIVO")
                {
                    BtnEdit.Enabled = true;
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

                
                TxtBillRangeId.Text = billRange.BILL_RANGE_ID.ToString();
                MskInitialRange.Text = billRange.BILL_RANGE_START;
                MskFinalRange.Text = billRange.BILL_RANGE_END;
            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if(h.MsgQuestion("¿Estas seguro de actualizar este registro?")=="S")
            {
                if (validateData() == 0)
                {
                    setValues();
                    BILL_RANGE updateBillRange = brc.getBillRange(Convert.ToInt32(TxtBillRangeId.Text));
                    updateBillRange.ESTABLISHMENT = establishment;
                    updateBillRange.EMISSION_POINT = emissionPoint;
                    updateBillRange.DOC_TYPE = doctype;
                    updateBillRange.INITIAL_RANGE = initialRange;
                    updateBillRange.FINAL_RANGE = finalRange;

                    if (brc.updateBillRange(updateBillRange) > 0)
                    {
                        h.MsgInfo("Rango de factura actualizado correctamente.");
                        startForm();
                    }
                    else
                    {
                        h.MsgError("Error al actualizar el rango de factura.");
                    }
                }

            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (h.MsgQuestion("¿Estas seguro de eliminar este registro?") == "S")
            {
                if (brc.deleteBillRange(Convert.ToInt32(TxtBillRangeId.Text)) > 0)
                {
                    h.MsgInfo("Rango de factura eliminado correctamente.");
                    startForm();
                }
                else
                {
                    h.MsgError("Error al eliminar el rango de factura.");
                }
            }

        }

        public void getBillRanges(string searchFilter="")
        {
            DgvBillRanges.Rows.Clear();
            var billRanges = brc.getBillRanges(searchFilter);

            if (billRanges.Count() == 0)
            {
                h.MsgInfo("No se encontraron registros");

                if (searchFilter != "")
                {
                    getBillRanges();
                }

                return;
            }

            foreach (var item in billRanges)
            {
                DgvBillRanges.Rows.Add(item.BILL_RANGE_ID, item.BILL_RANGE_START, item.BILL_RANGE_END, item.BILL_RANGE_STATE,Convert.ToDateTime(item.INSERTED_AT).ToShortDateString());
            }
        }

        private int validateData()
        {
            int error = 0;
            var lastBillRange = brc.getBillRangeInfo(brc.getLastIdBillRange());

            if (!MskInitialRange.MaskFull)
            {
                h.MsgInfo("Debe ingresar el rango inicial en formato correcto.");
                MskInitialRange.Focus();
                error++;
                return error;
            }

            if (!MskFinalRange.MaskFull)
            {
                h.MsgInfo("Debe ingresar el rango final en formato correcto.");
                MskFinalRange.Focus();
                error++;
                return error;
            }

            if (brc.existBillRange(MskInitialRange.Text, MskFinalRange.Text))
            {
                h.MsgInfo("El rango de factura ya existe.");
                error++;
                return error;
            }

            if (Convert.ToInt32(MskInitialRange.Text.Split('-')[3]) >= Convert.ToInt32(MskFinalRange.Text.Split('-')[3]))
            {
                h.MsgInfo("El rango final debe ser mayor al rango inicial.");
                error++;
                return error;
            }


            if (lastBillRange.BILL_RANGE_ID != Convert.ToInt32(TxtBillRangeId.Text))
            {
                if (Convert.ToInt32(MskInitialRange.Text.Split('-')[3]) <= lastBillRange.FINAL_RANGE)
                {
                    h.MsgInfo("El rango de factura inicial no puede ser menor o igual que el último rango configurado.");
                    error++;
                    return error;
                }
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
            lastUsed= initialRange - 1;
            userId = Config.User.userId;
            

        }

        private void BtnSave_Click(object sender, EventArgs e)
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
                newBillRange.BILL_RANGE_STATE= true;
                newBillRange.USER_CODE = userId;
                BILL_RANGE lastBillRange = brc.getBillRange(brc.getLastIdBillRange());

                if (brc.saveBillRange(newBillRange) > 0)
                {
                    lastBillRange.BILL_RANGE_STATE = false;

                    if(brc.updateBillRange(lastBillRange) > 0)
                    {
                        h.MsgInfo("Rango de factura guardado correctamente.");
                        startForm();
                    }
                }
                else
                {
                    h.MsgError("Error al guardar el rango de factura.");
                }
            }

        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            startForm();
        }
    }
}
