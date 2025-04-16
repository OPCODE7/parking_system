using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace parking.Helpers
{
    internal class App
    {
        /// <summary>
        /// Nombre de nuestra aplicación.
        /// </summary>
        public static string AppName = "PARKINGPRO";

        //MENSAJES DE LA APP

        /// <summary>
        /// Mensaje que indica que el registro fue insertado correctamente.
        /// </summary>
        public static string Msg0001 = "EL REGISTRO SE INSERTÓ CORRECTAMENTE!";

        /// <summary>
        /// Mensaje de confirmación para actualizar la información de un registro.
        /// </summary>
        public static string Msg0002 = "¿ACTUALIZAR LA INFORMACION DEL REGISTRO ACTUAL?";

        /// <summary>
        /// Mensaje que indica que los cambios se aplicaron correctamente.
        /// </summary>
        public static string Msg0003 = "LOS CAMBIOS SE APLICARON CORRECTAMENTE!";

        /// <summary>
        /// Mensaje de confirmación para eliminar un registro.
        /// </summary>
        public static string Msg0004 = "¿ELIMINAR EL REGISTRO SELECCIONADO?";

        /// <summary>
        /// Mensaje que indica que el registro fue eliminado correctamente.
        /// </summary>
        public static string Msg0005 = "EL REGISTRO SELECCIONADO SE ELIMINÓ CORRECTAMENTE!";

        /// <summary>
        /// Mensaje de confirmación para cancelar la operación en curso.
        /// </summary>
        public static string Msg0006 = "¿CANCELAR LA OPERACION EN CURSO?";

        /// <summary>
        /// Advertencia sobre la eliminación irreversible de información en la base de datos.
        /// </summary>
        public static string Msg0007 = "ELIMINAR INFORMACION DE LA BASE DE DATOS ES UNA OPERACION IRREVERSIBLE Y NO SE RECOMIENDA!" +
                                       "¿DESEA CONTINUAR Y ELIMINAR DEFINITIVAMENTE DE LA BASE DE DATOS EL REGISTRO SELECCIONADO?";

        /// <summary>
        /// Mensaje que indica que el registro fue eliminado correctamente de la base de datos.
        /// </summary>
        public static string Msg0008 = "EL REGISTRO SE ELIMINÓ CORRECTAMENTE DE LA BASE DE DATOS!";

        /// <summary>
        /// Mensaje de confirmación para restaurar un registro desde la papelera de reciclaje.
        /// </summary>
        public static string Msg0009 = "¿RESTAURAR DE LA PAPELERA DE RECICLAJE EL REGISTRO SELECCIONADO?";

        /// <summary>
        /// Mensaje que indica que el registro fue restaurado correctamente.
        /// </summary>
        public static string Msg0010 = "EL REGISTRO SE RESTAURÓ CORRECTAMENTE!";

        /// <summary>
        /// Mensaje de error al cargar los datos de un registro.
        /// </summary>
        public static string Msg0011 = "ERROR AL CARGAR LOS DATOS DEL REGISTRO SELECCIONADO!";

        /// <summary>
        /// Mensaje que indica que no hay registros para mostrar.
        /// </summary>
        public static string Msg0012 = "SIN REGISTROS QUE MOSTRAR!";

        /// <summary>
        /// Mensaje que indica que no se encontró un registro que cumpla con la condición.
        /// </summary>
        public static string Msg0013 = "NO SE ENCONTRO NINGUN REGISTRO QUE CUMPLA CON LA CONDICION!";

        /// <summary>
        /// Mensaje de error al cargar los datos de la aplicación.
        /// </summary>
        public static string Msg0014 = "ERROR AL CARGAR LOS DATOS DE LA APLICACION!";

        /// <summary>
        /// Mensaje de error al insertar un registro.
        /// </summary>
        public static string Msg0015 = "ERROR AL INSERTAR EL REGISTRO!";

        /// <summary>
        /// Mensaje de error al eliminar un registro.
        /// </summary>
        public static string Msg0016 = "ERROR AL ELIMINAR EL REGISTRO!";

        /// <summary>
        /// Mensaje de error al actualizar un registro.
        /// </summary>
        public static string Msg0017 = "ERROR AL ACTUALIZAR EL REGISTRO!";

        /// <summary>
        /// Mensaje de error al recuperar un registro.
        /// </summary>
        public static string Msg0018 = "ERROR AL RECUPERAR EL REGISTRO!";

        /// <summary>
        /// Mensaje de error al eliminar registro con datos asociados.
        /// </summary>
        public static string Msg0019 = "NO SE PUEDE ELIMINAR EL REGISTRO PORQUE ESTÁ ASOCIADO CON OTROS DATOS!";

        /// <summary>
        /// Mensaje de error al cargar los datos del archivo de configuración.
        /// </summary>

        public static string Msg0020 = "NO SE CARGARON LOS DATOS DEL ARCHIVO DE CONFIGURACIÓN";

        /// <summary>
        /// Mensaje de error fatal al no encontrar el archivo de configuración.
        /// </summary>
        public static string Msg0021 = "!ERROR FATAL! EL ARCHIVO DE CONFIGURACIÓN NO EXISTE";

        /// <summary>
        /// Mensaje de error fatal al no poder conectar a la base de datos.
        /// </summary>

        public static string Msg0022= "!ERROR FATAL! NO SE PUEDE CONECTAR A LA BASE DE DATOS, VERIFIQUE LOS DATOS DE CONEXION EN EL ARCHIVO DE CONFIGURACION";




    }
}
