using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace parking.Helpers
{
    internal class Helpers
    {
        /// <summary>
        /// Muestra un cuadro de diálogo de advertencia con el mensaje especificado.
        /// </summary>
        /// <param name="msg">Mensaje a mostrar.</param>
        public void MsgWarning(string msg)
        {
            MessageBox.Show(msg, "ATENCIÓN", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Muestra un cuadro de diálogo indicando que un proceso se realizó exitosamente.
        /// </summary>
        /// <param name="msg">Mensaje a mostrar.</param>
        public void MsgSuccess(string msg)
        {
            MessageBox.Show(msg, "ÉXITO", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de error con el mensaje especificado.
        /// </summary>
        /// <param name="msg">Mensaje de error a mostrar.</param>
        public void MsgError(string msg)
        {
            MessageBox.Show(msg, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra un cuadro de diálogo informativo con el mensaje proporcionado.
        /// </summary>
        /// <param name="msg">Mensaje informativo a mostrar.</param>
        public void MsgInfo(string msg)
        {
            MessageBox.Show(msg, "INFORMACIÓN", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Elimina caracteres prohibidos de una cadena para prevenir inyecciones u otros errores.
        /// </summary>
        /// <param name="str">Cadena de texto a sanitizar.</param>
        /// <returns>Cadena limpia sin caracteres prohibidos.</returns>
        public string SanitizeStr(string str)
        {
            string strout = "";
            string[] forbiddenchars = { "'", "=", "-", ">", ";", "/", "!" };
            int i, j;
            int coincidences;

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

        /// <summary>
        /// Permite únicamente el ingreso de caracteres numéricos o retroceso en un campo de entrada.
        /// </summary>
        /// <param name="e">Evento de tecla presionada.</param>
        /// <returns>True si el carácter es numérico o retroceso, de lo contrario False.</returns>
        public bool GetOnlyNumbers(KeyPressEventArgs e)
        {
            bool resp = false;
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char)8)
            {
                resp = true;
            }

            return resp;
        }

        /// <summary>
        /// Convierte una cadena en un valor numérico (double).
        /// </summary>
        /// <param name="str">Cadena a convertir.</param>
        /// <returns>Valor double equivalente o 0 si ocurre un error.</returns>
        public double GetNumericValue(string str)
        {
            double value = 0;
            if (double.TryParse(str, out value))
            {
                value = Convert.ToDouble(str);
            }
            else
            {
                MsgWarning("Error al obtener el valor numérico de: " + str);
                value = 0;
            }
            return value;
        }

        /// <summary>
        /// Muestra un cuadro de diálogo de confirmación y retorna la respuesta del usuario.
        /// </summary>
        /// <param name="msg">Mensaje de confirmación a mostrar.</param>
        /// <returns>"S" si se confirma con Sí, "N" si se elige No.</returns>
        public string MsgQuestion(string msg)
        {
            string Op = "N";
            if (MessageBox.Show(msg, "CONFIRMAR", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Op = "S";
            }
            return Op;
        }

        /// <summary>
        /// Convierte una cadena alfanumérica en un número decimal (double).
        /// </summary>
        /// <param name="value">Cadena a convertir.</param>
        /// <returns>Valor numérico en formato double o 0 si ocurre un error.</returns>
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

        /// <summary>
        /// Convierte un monto numérico a su representación en letras (español).
        /// </summary>
        /// <param name="amount">Monto a convertir.</param>
        /// <param name="currency">Moneda a usar en la conversión. Por defecto "lempiras".</param>
        /// <param name="centsFormat">
        /// Formato para los centavos:
        /// 1 - en letras (ej: "con cincuenta centavos"),
        /// 2 - en número (ej: "con 50 centavos"),
        /// 3 - como fracción (ej: "con 50/100").
        /// </param>
        /// <returns>Cadena con el monto expresado en letras.</returns>
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
                result += $" {currency} con ";
                switch (centsFormat)
                {
                    case 1:
                        result += ConvertNumberToWords(decimalPart) + " centavos";
                        break;
                    case 2:
                        result += decimalPart + " centavos";
                        break;
                    case 3:
                    default:
                        result += $"{decimalPart:D2}/100";
                        break;
                }
                return result;
            }

            return result + $" {currency}";
        }



    }
}

