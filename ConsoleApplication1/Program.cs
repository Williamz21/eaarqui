using Structurizr;
using Structurizr.Api;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Banking();
        }

        static void Banking()
        {
            const long workspaceId = 82328;
            const string apiKey = "a2305e80-2b3c-419c-9858-974e84d26f2f";
            const string apiSecret = "45a75bee-1813-44c7-8399-0fa996482260";

            StructurizrClient structurizrClient = new StructurizrClient(apiKey, apiSecret);
            Workspace workspace = new Workspace("C4 Model - TechnoGym Unified Ecosystem", "Sistema de TechnoGym Unified Ecosystem");
            Model model = workspace.Model;
            ViewSet viewSet = workspace.Views;

            // 1. Diagrama de Contexto
            SoftwareSystem technoGym = model.AddSoftwareSystem("TechnoGym Unified Ecosystem", "Permite la adquisición de productos y servicios de TechnoGym");
            SoftwareSystem googleSystem = model.AddSoftwareSystem("Google Tools", "Herramientas de Google para el desarrollo de TechnoGym");

            Person deportista = model.AddPerson("Deportista", "Usuario que utiliza los productos de TechnoGym.");
            Person userComercial = model.AddPerson("User Comercial", "Usuario que ofrece los productos de gimnasios de TechnoGym a sus clientes.");
            Person personal = model.AddPerson("Fitness", "Usuario que utiliza la plataforma TechnoGym para crear planes de entrenamiento para sus clientes.");
            Person developer = model.AddPerson("Developer", "Usuario que desarrolla la plataforma TechnoGym.");

            technoGym.Uses(googleSystem, "Utiliza");
            deportista.Uses(technoGym, "Realiza consultas a la plataforma TechnoGym Unified Ecosystem");
            userComercial.Uses(technoGym, "Realiza consultas a la plataforma TechnoGym Unified Ecosystem");
            personal.Uses(technoGym, "Realiza consultas a la plataforma TechnoGym Unified Ecosystem");
            developer.Uses(technoGym, "Realiza consultas a la plataforma TechnoGym Unified Ecosystem");

            SystemContextView contextView = viewSet.CreateSystemContextView(technoGym, "Contexto", "Diagrama de contexto");
            contextView.PaperSize = PaperSize.A4_Landscape;
            contextView.AddAllSoftwareSystems();
            contextView.AddAllPeople();

            // Tags
            technoGym.AddTags("SistemaTechnoGym");
            deportista.AddTags("Deportista");
            userComercial.AddTags("User Comercial");
            personal.AddTags("Fitness");
            developer.AddTags("Developer");
            googleSystem.AddTags("Google");
            
            Styles styles = viewSet.Configuration.Styles;
            styles.Add(new ElementStyle("Deportista") { Background = "#0a60ff", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("User Comercial") { Background = "#08427b", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Fitness") { Background = "#facc2e", Color = "#ffffff", Shape = Shape.Person });
            styles.Add(new ElementStyle("Developer") { Background = "#008f39", Shape = Shape.Robot });
            styles.Add(new ElementStyle("SistemaTechnoGym") { Background = "#008f39", Color = "#ffffff", Shape = Shape.RoundedBox });
            styles.Add(new ElementStyle("Google") { Background = "#90714c", Color = "#ffffff", Shape = Shape.RoundedBox });

            // 2. Diagrama de Contenedores
            Container mobileApplication = technoGym.AddContainer("Mobile App", "Permite que los usuarios accedan a programas personales desde cualquier lugar.", "Kotlin, Swift");
            Container webApplication = technoGym.AddContainer("Web App", "Permite que los usuarios accedan a programas personales desde cualquier lugar.", "Angular, Typescript, Angular Material");
            Container apiGateway = technoGym.AddContainer("API Gateway", "API Gateway", "Spring Boot port 8080");
            Container shared = technoGym.AddContainer("Shared Context", "Bounded Context", "Spring Boot port 8081");
            Container airportContext = technoGym.AddContainer("Identity & Access Management Context", "Bounded Context", "Spring Boot port 8082");
            Container aircraftInventoryContext = technoGym.AddContainer("Ecommerce & Store Management Context", "Bounded Context", "Spring Boot port 8083");
            Container vaccinesInventoryContext = technoGym.AddContainer("Inventory & Supply Chain Context", "Bounded Context", "Spring Boot port 8084");
            Container monitoringContext = technoGym.AddContainer("Accounts & User Profiles Context", "Bounded Context", "Spring Boot port 8085");
            Container training = technoGym.AddContainer("Training Services Context", "Bounded Context", "Spring Boot port 8086");
            Container business = technoGym.AddContainer("Business Sector Services Context", "Bounded Context", "Spring Boot port 8087");
            Container content = technoGym.AddContainer("Content & Streaming Management Services Context", "Bounded Context", "Spring Boot port 8088");
            Container digital = technoGym.AddContainer("Digital AI Coaching Context", "Bounded Context", "Spring Boot port 8089");
            Container data = technoGym.AddContainer("Data Analytics & Recommendations Context", "Bounded Context", "Spring Boot port 8090");
            
            Container messageBus = technoGym.AddContainer("Bus de Mensajes", "Transporte de eventos del dominio.", "RabbitMQ");
            
            Container sharedDatabase =                      technoGym.AddContainer("Shared Context DB", "", "Oracle");
            Container airportContextDatabase =              technoGym.AddContainer("Identity & Access Management Context DB", "", "Oracle");
            Container aircraftInventoryContextDatabase =    technoGym.AddContainer("Ecommerce & Store Management Context DB", "", "Oracle");
            Container vaccinesInventoryContextDatabase =    technoGym.AddContainer("Inventory & Supply Chain Context DB", "", "Oracle");
            Container monitoringContextDatabase =           technoGym.AddContainer("Accounts & User Profiles Context DB", "", "Oracle");
            Container trainingDatabase =                    technoGym.AddContainer("Training Services Context DB", "", "Oracle");
            Container businessDatabase =                    technoGym.AddContainer("Business Sector Services DB", "", "Oracle");
            Container contentDatabase =                     technoGym.AddContainer("Content & Streaming Management Services Context DB", "", "Oracle");
            Container digitalDatabase =                     technoGym.AddContainer("Digital AI Coaching DB", "", "Oracle");
            Container dataDatabase =                        technoGym.AddContainer("Data Analytics & Recommendations DB", "", "Oracle");
            
            
            deportista.Uses(mobileApplication, "Consulta");
            deportista.Uses(webApplication, "Consulta");
            userComercial.Uses(mobileApplication, "Consulta");
            userComercial.Uses(webApplication, "Consulta");
            personal.Uses(mobileApplication, "Consulta");
            personal.Uses(webApplication, "Consulta");
            
            mobileApplication.Uses(apiGateway, "API Request", "JSON/HTTPS");
            webApplication.Uses(apiGateway, "API Request", "JSON/HTTPS");
            developer.Uses(apiGateway, "API Request", "JSON/HTTPS");
            apiGateway.Uses(shared, "API Request", "JSON/HTTPS");
            apiGateway.Uses(airportContext, "API Request", "JSON/HTTPS");
            apiGateway.Uses(aircraftInventoryContext, "API Request", "JSON/HTTPS");
            apiGateway.Uses(vaccinesInventoryContext, "API Request", "JSON/HTTPS");
            apiGateway.Uses(monitoringContext, "API Request", "JSON/HTTPS");
            apiGateway.Uses(training, "API Request", "JSON/HTTPS");
            apiGateway.Uses(business, "API Request", "JSON/HTTPS");
            apiGateway.Uses(content, "API Request", "JSON/HTTPS");
            apiGateway.Uses(digital, "API Request", "JSON/HTTPS");
            apiGateway.Uses(data, "API Request", "JSON/HTTPS");
            
            shared.Uses(messageBus, "Publica y consume eventos del dominio");
            shared.Uses(sharedDatabase, "", "JDBC");
            airportContext.Uses(messageBus, "Publica y consume eventos del dominio");
            airportContext.Uses(airportContextDatabase, "", "JDBC");
            aircraftInventoryContext.Uses(messageBus, "Publica y consume eventos del dominio");
            aircraftInventoryContext.Uses(aircraftInventoryContextDatabase, "", "JDBC");
            vaccinesInventoryContext.Uses(messageBus, "Publica y consume eventos del dominio");
            vaccinesInventoryContext.Uses(vaccinesInventoryContextDatabase, "", "JDBC");
            monitoringContext.Uses(messageBus, "Publica y consume eventos del dominio");
            monitoringContext.Uses(monitoringContextDatabase, "", "JDBC");
            training.Uses(messageBus, "Publica y consume eventos del dominio");
            training.Uses(trainingDatabase, "", "JDBC");
            business.Uses(messageBus, "Publica y consume eventos del dominio");
            business.Uses(businessDatabase, "", "JDBC");
            content.Uses(messageBus, "Publica y consume eventos del dominio");
            content.Uses(contentDatabase, "", "JDBC");
            digital.Uses(messageBus, "Publica y consume eventos del dominio");
            digital.Uses(digitalDatabase, "", "JDBC");
            data.Uses(messageBus, "Publica y consume eventos del dominio");
            data.Uses(dataDatabase, "", "JDBC");

            // Tags
            mobileApplication.AddTags("MobileApp");
            webApplication.AddTags("WebApp");
            apiGateway.AddTags("APIGateway");
            
            shared.AddTags("FlightPlanningContext");
            sharedDatabase.AddTags("FlightPlanningContextDatabase");
            airportContext.AddTags("AirportContext");
            airportContextDatabase.AddTags("AirportContextDatabase");
            aircraftInventoryContext.AddTags("AircraftInventoryContext");
            aircraftInventoryContextDatabase.AddTags("AircraftInventoryContextDatabase");
            vaccinesInventoryContext.AddTags("VaccinesInventoryContext");
            vaccinesInventoryContextDatabase.AddTags("VaccinesInventoryContextDatabase");
            monitoringContext.AddTags("MonitoringContext");
            monitoringContextDatabase.AddTags("MonitoringContextDatabase");
            training.AddTags("FlightPlanningContext");
            trainingDatabase.AddTags("FlightPlanningContextDatabase");
            business.AddTags("FlightPlanningContext");
            businessDatabase.AddTags("FlightPlanningContextDatabase");
            content.AddTags("FlightPlanningContext");
            contentDatabase.AddTags("FlightPlanningContextDatabase");
            digital.AddTags("FlightPlanningContext");
            digitalDatabase.AddTags("FlightPlanningContextDatabase");
            data.AddTags("FlightPlanningContext");
            dataDatabase.AddTags("FlightPlanningContextDatabase");
            
            messageBus.AddTags("MessageBus");
            
            styles.Add(new ElementStyle("MobileApp") { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.MobileDevicePortrait, Icon = "" });
            styles.Add(new ElementStyle("WebApp") { Background = "#9d33d6", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
            styles.Add(new ElementStyle("LandingPage") { Background = "#929000", Color = "#ffffff", Shape = Shape.WebBrowser, Icon = "" });
            styles.Add(new ElementStyle("APIGateway") { Shape = Shape.RoundedBox, Background = "#0000ff", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("FlightPlanningContext") { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("FlightPlanningContextDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("AirportContext") { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("AirportContextDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("AircraftInventoryContext") { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("AircraftInventoryContextDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("VaccinesInventoryContext") { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("VaccinesInventoryContextDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("MonitoringContext") { Shape = Shape.Hexagon, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MonitoringContextDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("MonitoringContextReplicaDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("MonitoringContextReactiveDatabase") { Shape = Shape.Cylinder, Background = "#ff0000", Color = "#ffffff", Icon = "" });
            styles.Add(new ElementStyle("MessageBus") { Width = 850, Background = "#fd8208", Color = "#ffffff", Shape = Shape.Pipe, Icon = "" });

            ContainerView containerView = viewSet.CreateContainerView(technoGym, "Contenedor", "Diagrama de contenedores");
            contextView.PaperSize = PaperSize.A4_Landscape;
            containerView.AddAllElements();

            // 3. Diagrama de Componentes
            Component domainLayer = monitoringContext.AddComponent("Domain Layer", "", "Spring Boot");
            Component monitoringController = monitoringContext.AddComponent("Monitoring Controller", "REST API endpoints de monitoreo.", "Spring Boot REST Controller");
            Component monitoringApplicationService = monitoringContext.AddComponent("Monitoring Application Service", "Provee métodos para el monitoreo, pertenece a la capa Application de DDD", "Spring Component");
            Component flightRepository = monitoringContext.AddComponent("Flight Repository", "Información del vuelo", "Spring Component");
            Component vaccineLoteRepository = monitoringContext.AddComponent("VaccineLote Repository", "Información de lote de vacunas", "Spring Component");
            Component locationRepository = monitoringContext.AddComponent("Location Repository", "Ubicación del vuelo", "Spring Component");
            Component aircraftSystemFacade = monitoringContext.AddComponent("Aircraft System Facade", "", "Spring Component");

            apiGateway.Uses(monitoringController, "", "JSON/HTTPS");
            monitoringController.Uses(monitoringApplicationService, "Invoca métodos de monitoreo");
            monitoringController.Uses(aircraftSystemFacade, "Usa");
            monitoringApplicationService.Uses(domainLayer, "Usa", "");
            monitoringApplicationService.Uses(flightRepository, "", "JDBC");
            monitoringApplicationService.Uses(vaccineLoteRepository, "", "JDBC");
            monitoringApplicationService.Uses(locationRepository, "", "JDBC");
            flightRepository.Uses(monitoringContextDatabase, "", "JDBC");
            vaccineLoteRepository.Uses(monitoringContextDatabase, "", "JDBC");
            locationRepository.Uses(monitoringContextDatabase, "", "JDBC");

            // Tags
            domainLayer.AddTags("DomainLayer");
            monitoringController.AddTags("MonitoringController");
            monitoringApplicationService.AddTags("MonitoringApplicationService");
            flightRepository.AddTags("FlightRepository");
            vaccineLoteRepository.AddTags("VaccineLoteRepository");
            locationRepository.AddTags("LocationRepository");
            aircraftSystemFacade.AddTags("AircraftSystemFacade");
            
            styles.Add(new ElementStyle("DomainLayer") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MonitoringController") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MonitoringApplicationService") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("MonitoringDomainModel") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("FlightStatus") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("FlightRepository") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("VaccineLoteRepository") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("LocationRepository") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });
            styles.Add(new ElementStyle("AircraftSystemFacade") { Shape = Shape.Component, Background = "#facc2e", Icon = "" });

            ComponentView componentView = viewSet.CreateComponentView(monitoringContext, "Components", "Component Diagram");
            componentView.PaperSize = PaperSize.A4_Landscape;
            componentView.Add(mobileApplication);
            componentView.Add(webApplication);
            componentView.Add(apiGateway);
            componentView.Add(monitoringContextDatabase);
            componentView.Add(googleSystem);
            componentView.AddAllComponents();

            structurizrClient.UnlockWorkspace(workspaceId);
            structurizrClient.PutWorkspace(workspaceId, workspace);
        }
    }
}