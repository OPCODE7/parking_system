using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Helpers
{
    internal class Helpers
    {
        //Metodo MsgWarning
        //Envia una advertencia a pantalla en cuadro de dialogo 
        public void MsgWarning(string msg)
        {
            MessageBox.Show(msg, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        //Fin Metodo MsgWarning

        //Metodo MsgSuccess
        //Envia un cuadro de dialogo a pantalla indicando que un proceso se realizo exitosamente
        public void MsgSuccess(string msg)
        {
            MessageBox.Show(msg, "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Fin MsgSuccess

        public void MsgError(string msg)
        {

            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void MsgInfo(string msg)
        {
            MessageBox.Show(msg, "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        //Metodo SanitizeStr
        public string SanitizeStr(string str)
        {
            string strout = "";//cadena de salida

            //arreglo de caracteres prohibidos
            string[] forbiddenchars = { "'", "=", "-", ">", ";", "/", "!" };
            int i, j; //variables para interar ciclos
            int coincidences;// variable de coincidencias

            for (i = 0; i < str.Length; i++)
            {
                coincidences = 0;
                for (j = 0; j < forbiddenchars.Length; j++)
                {
                    coincidences = str.Substring(i, 1) == forbiddenchars[j] ? coincidences + 1 : coincidences + 0;
                }
                strout = coincidences == 0 ? strout + str.Substring(i, 1) : strout;

            }
            return strout;



        }
        //Fin Metodo SanitizeStr


        //Metodo GetOnlyNumbers
        //Bloquear cualquier caracter que no sea numero
        public Boolean GetOnlyNumbers(KeyPressEventArgs e)
        {
            Boolean resp = false;
            if (Char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                resp = true;

            }

            return resp;

        }
        //Fin GetOnlyNumbers

        //Metodo GetNumericValue
        //Devolver el valor numerico de un numero
        public double GetNumericValue(string str)
        {
            double value = 0;
            if (double.TryParse(str, out value))
            {
                value = Convert.ToDouble(str);

            }
            else
            {
                MsgWarning("Error al obtener el valor numerico de! " + str);
                value = 0;
            }
            return value;
        }
        // Fin GetNumericValue

        //MetodoMsgQuestion
        //Manda un cuadro de dialogo en el cual se confirma si se quiere realizar algun proceso
        public string MsgQuestion(string msg)
        {
            ; string Op = "N";
            if (MessageBox.Show(msg, "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Op = "S";

            }
            return Op;

        }
        //FinMetodoMsgQuestion

        //Metodo ConvertDouble
        //Metodo para convertir datos alfanumericos a double
        public double ConvertDouble(string value)
        {
            double num;
            if (double.TryParse(value, out num))
            {
                num = Convert.ToDouble(value);
            }
            else
            {
                MessageBox.Show("El valor debe ser numérico");
                num = 0;
            }
            return num;

        }

        //Fin Metodo ConvertDouble

        //Metodo ConvertAmountToWords
        //Convierte un monto en letras


        public string ConvertAmountToWords(decimal amount, string currency = "lempiras", int centsFormat = 1)
        {
            string[] units = { "cero", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez",
                       "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve" };

            string[] tens = { "", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };

            string[] hundreds = { "", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos",
                          "setecientos", "ochocientos", "novecientos" };

            string ConvertNumberToWords(long number)
            {
                if (number < 20) return units[number];
                if (number < 100) return tens[number / 10] + (number % 10 == 0 ? "" : " y " + units[number % 10]);
                if (number < 1000) return (number == 100 ? "cien" : hundreds[number / 100] + " " + ConvertNumberToWords(number % 100)).Trim();
                if (number < 1000000) return (number / 1000 == 1 ? "mil" : ConvertNumberToWords(number / 1000) + " mil") +
                                        (number % 1000 == 0 ? "" : " " + ConvertNumberToWords(number % 1000));
                if (number < 1000000000) return ConvertNumberToWords(number / 1000000) + " millones" +
                                        (number % 1000000 == 0 ? "" : " " + ConvertNumberToWords(number % 1000000));

                return "Número fuera de rango";
            }

            if (amount == 0) return "cero";

            long integerPart = (long)Math.Floor(amount);
            int decimalPart = (int)((amount - integerPart) * 100);

            string result = ConvertNumberToWords(integerPart).Trim();

            if (decimalPart > 0)
            {
                result += " con ";
                switch (centsFormat)
                {
                    case 1: // "con cincuenta y seis centavos"
                        result += ConvertNumberToWords(decimalPart) + " centavos";
                        break;
                    case 2: // "con 56 centavos"
                        result += decimalPart + " centavos";
                        break;
                    case 3: // "con 56/100"
                    default:
                        result += $"{decimalPart:D2}/100";
                        break;
                }
            }

            return result + $" {currency}";
        } 
    
        //FinMetodoConvertAmountToWords
    }
}

