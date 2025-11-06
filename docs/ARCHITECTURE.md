# Arquitectura del Portal Inteligente de Proveedores

Este documento resume la solución propuesta en .NET para automatizar el ciclo de vida de proveedores, facturas y conciliaciones integradas con Dynamics 365 F&O, Azure Document Intelligence y Azure OpenAI.

## Componentes principales

### 1. Frontend (Blazor WebAssembly)
- Registro y administración de proveedores.
- Subida de documentos PDF para análisis de Azure Document Intelligence.
- Dashboard con seguimiento de facturas y estados de validación.

### 2. Backend API (ASP.NET Core Web API)
- Autenticación mediante Azure AD B2C con JWT.
- Endpoints REST para proveedores, facturas y análisis documental.
- Integración con Azure Document Intelligence y capa de infraestructura compartida.

### 3. Capa de Aplicación e Infraestructura
- Servicios reutilizables para lógica de dominio.
- `InMemoryDataStore` como repositorio temporal (reemplazable por SQL Server).
- Servicios listos para conectarse con Dynamics 365 F&O vía OData.

### 4. Inteligencia Artificial
- `DocumentIntelligenceService` para aprovechar Azure Document Intelligence.
- Integración planificada con Azure Machine Learning y Azure OpenAI (no implementada en esta versión de referencia).

## Flujo de alto nivel

1. Un proveedor se registra a través del portal web.
2. El backend calcula un puntaje de riesgo inicial y almacena la información.
3. El proveedor sube facturas u órdenes de compra, que se procesan mediante Azure Document Intelligence.
4. Los datos extraídos se validan y se concilian con Dynamics 365 F&O.
5. El estado de la factura se actualiza y el proveedor recibe notificaciones mediante Power Automate y soporte vía chatbot de Azure OpenAI.

## Personalización sugerida

- Sustituir `InMemoryDataStore` por Entity Framework Core con SQL Server utilizando el script de base de datos incluido en la carpeta `database`.
- Configurar los valores reales de Azure AD B2C, Azure Storage y Document Intelligence en `backend/Portal.Api/appsettings.json`.
- Implementar servicios adicionales para riesgo del proveedor (Azure Machine Learning) y chatbot contextual (Azure OpenAI) siguiendo el mismo patrón de inyección de dependencias.

## Despliegue

- Backend: Azure App Service o contenedores en Azure Kubernetes Service.
- Frontend: Azure Static Web Apps o Azure Front Door para distribución global.
- Integraciones: Azure Key Vault para secretos, Power Automate y Power BI Embedded para automatización y analítica.
