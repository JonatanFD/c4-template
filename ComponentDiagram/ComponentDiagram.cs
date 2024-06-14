using c4_model_template;
using ctn_diagram;
using ctx_diagram;

using Structurizr;


namespace component_diagram
{


    public class SomeComponent
    {
        private readonly C4 c4;
        private readonly ContainerDiagram containerDiagram;
        private readonly ContextDiagram contextDiagram;
        private readonly string componentTag = "Component";

        public Component DomainLayer { get; private set; }
        public Component InterfaceLayer { get; private set; }
        public Component ApplicationLayer { get; private set; }
        public Component InfrastructureLayer { get; private set; }

        public SomeComponent(C4 c4, ContainerDiagram containerDiagram, ContextDiagram contextDiagram)
        {
            this.c4 = c4;
            this.containerDiagram = containerDiagram;
            this.contextDiagram = contextDiagram;
        }


        public void Generate()
        {
            // agegando componentes 
            DomainLayer = containerDiagram.ApiRest.AddComponent("Domain Layer Server Connection", "", "NodeJS (NestJS)");
            InterfaceLayer = containerDiagram.ApiRest.AddComponent("Interface Layer Server Connection", "", "NodeJS (NestJS)");
            InfrastructureLayer = containerDiagram.ApiRest.AddComponent("Infrastructure Layer Server Connection", "", "NodeJS (NestJS)");
            ApplicationLayer = containerDiagram.ApiRest.AddComponent("Application Layer Server Connection", "", "NodeJS (NestJS)");

            // agregar las relaciones de uso 
            InterfaceLayer.Uses(ApplicationLayer, "", "");
            ApplicationLayer.Uses(DomainLayer, "", "");
            ApplicationLayer.Uses(InfrastructureLayer, "", "");
            InfrastructureLayer.Uses(DomainLayer, "", "");
            InfrastructureLayer.Uses(contextDiagram.SomeSystem, "Usa", "");
            InfrastructureLayer.Uses(contextDiagram.SomeThird, "Usa", "");


            // agregar 

            // string title = "Server Connection BC Component Diagram";
            string title = "[name] Component Diagram";
            ComponentView componentView = c4.ViewSet.CreateComponentView(containerDiagram.ApiRest, title, title);
            componentView.Title = title;
            // contenedores asociados
            componentView.Add(contextDiagram.SomeSystem);
            componentView.Add(contextDiagram.SomeThird);

            // elementos propios
            componentView.Add(DomainLayer);
            componentView.Add(InterfaceLayer);
            componentView.Add(ApplicationLayer);
            componentView.Add(InfrastructureLayer);
        }

    }

}