# Portal Inteligente de Proveedores

Solución de referencia Full Stack basada en .NET para automatizar el ciclo de vida de proveedores, con integración a Dynamics 365 Finance & Operations y servicios de Azure (Document Intelligence, Machine Learning y OpenAI).

## Estructura del proyecto

```
backend/
  Portal.sln
  Portal.Api/           # ASP.NET Core Web API con Azure AD B2C y Azure Document Intelligence
  Portal.Web/           # Frontend Blazor WebAssembly para proveedores
  Portal.Domain/        # Entidades de dominio (proveedores, facturas, documentos)
  Portal.Application/   # Interfaces de aplicación y contratos de servicios
  Portal.Infrastructure/# Servicios concretos e integración con almacenamiento

database/
  portal_supplier_db.sql # Script de SQL Server

docs/
  ARCHITECTURE.md
```

## Requisitos previos

- .NET 8 SDK
- Node.js (opcional para tooling de frontend)
- Azure Subscription con Azure AD B2C, Document Intelligence, Storage y OpenAI
- Dynamics 365 F&O habilitado para uso de APIs OData
- SQL Server 2019 o superior

## Puesta en marcha

1. **Backend API**
   ```bash
   cd backend
   dotnet build Portal.sln
   dotnet run --project Portal.Api/Portal.Api.csproj
   ```
   Configura las claves reales en `backend/Portal.Api/appsettings.json` o mediante variables de entorno.

2. **Frontend Blazor**
   ```bash
   cd backend/Portal.Web
   dotnet run
   ```
   Actualiza `Portal.Web/Services/PortalApiClient.cs` con la URL real del backend si es diferente.

3. **Base de datos SQL Server**
   Ejecuta `database/portal_supplier_db.sql` en tu instancia de SQL Server para crear el esquema base. Posteriormente reemplaza `InMemoryDataStore` por un contexto de Entity Framework Core conectado a esta base de datos.

4. **Integraciones adicionales**
   - Configura Power Automate para notificaciones automáticas de aprobaciones y credenciales.
   - Habilita Power BI Embedded para los tableros analíticos del portal.
   - Incorpora Azure Machine Learning para el modelo de riesgo y Azure OpenAI para el chatbot de soporte.

## Seguridad

- Autenticación basada en Azure AD B2C y tokens JWT.
- Recomendado utilizar Azure Key Vault para almacenar secretos y credenciales.
- Azure Storage con SAS o Managed Identities para proteger documentos.

## Próximos pasos sugeridos

- Implementar repositorios SQL Server con Entity Framework Core.
- Conectar servicios reales de Dynamics 365 F&O mediante OData.
- Entrenar modelos personalizados en Azure Document Intelligence y Azure Machine Learning.
- Agregar chatbot de Azure OpenAI utilizando Azure Bot Service.
