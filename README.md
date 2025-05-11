# 🅿️ Sistema de Gestión de Parqueo

Este sistema ha sido desarrollado para administrar de forma eficiente un parqueo, permitiendo el control total sobre los ingresos, egresos, espacios, clientes, usuarios y configuraciones generales. Está diseñado como una aplicación de escritorio utilizando tecnologías modernas y un enfoque modular.

## 🧰 Tecnologías Utilizadas

- **Lenguaje:** C#
- **Framework:** .NET Framework (WinForms)
- **ORM:** Entity Framework
- **Diseño:** Patrón MVC (Modelo-Vista-Controlador)
- **Reportes:** RDLC con ReportViewer

## 📦 Módulos del Sistema

El sistema cuenta con múltiples módulos organizados por funcionalidad, permitiendo una administración integral del negocio:

### 👥 Gestión de Personal
- Empleados  
- Cargos  
- Horarios  
- Salarios  

### 🚗 Gestión del Parqueo
- Tipos de parqueo  
- Espacios de parqueo  
- Tarifas  
- Entradas  
- Salidas  

### 🧑‍💼 Gestión de Clientes y Usuarios
- Clientes  
- Gestión de usuarios:
  - Roles  
  - Permisos  
  - Usuarios  
  - Configuración de permisos  

### 📊 Reportes
- Reportes de entradas y salidas  
- Reportes de facturas  
- Reportes de ingresos financieros  

### ⚙️ Configuración del Sistema
- Información de la empresa  
- Rangos de facturación  
- Configuración del servidor  
- Bitácora del sistema (auditoría y trazabilidad)

## 📈 Características Clave

- Generación de reportes filtrables.
- Soporte para gráficos dinámicos en RDLC.
- Administración de usuarios con roles y permisos personalizables.
- Control detallado del parqueo, desde tarifas hasta los espacios disponibles.
- Auditoría a través de la bitácora del sistema.
- Configuración de parámetros clave del negocio desde el sistema.

## 🛠️ Estructura Basada en MVC

El proyecto está estructurado siguiendo el patrón MVC para WinForms, separando responsabilidades de:
- **Modelos:** Entidades del dominio.
- **Vistas:** Formularios y reportes.
- **Controladores:** Lógica de negocio y comunicación con la base de datos.

## ⚙️ Requisitos

- Visual Studio 2019 o superior
- .NET Framework 4.8 o superior
- SQL Server
- Microsoft ReportViewer
- Controladores ODBC/Entity Framework
- Access
- Windows 10 o superior

---

