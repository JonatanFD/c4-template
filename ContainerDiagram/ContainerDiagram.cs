
using c4_model_template;
using ctx_diagram;
using Structurizr;


namespace ctn_diagram
{
  public class ContainerDiagram
  {

    private readonly C4 c4;
    private readonly ContextDiagram contextDiagram;


    public Container SomeContainer { get; private set; }
    public Container SomeContainer2 { get; private set; }
    public Container SomeContainer3 { get; private set; }


    // Api
    public Container ApiRest { get; private set; }

    public ContainerDiagram(C4 c4, ContextDiagram contextDiagram)
    {
      this.c4 = c4;
      this.contextDiagram = contextDiagram;
    }

    public void Generate()
    {

      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      // (name, description)
      SomeContainer = contextDiagram.SomeMain.AddContainer("Some Container", "Some description", "Some Technology");
      SomeContainer2 = contextDiagram.SomeMain.AddContainer("Some Container 2", "Some description", "Some Technology");
      SomeContainer3 = contextDiagram.SomeMain.AddContainer("Some Container 3", "Some description", "Some Technology");

      ApiRest = contextDiagram.SomeMain.AddContainer("Api Rest", "Some description", "Some Technology");

      // se crean las relaciones entre los elementos
      contextDiagram.SomePerson.Uses(SomeContainer, "Use");
      contextDiagram.SomeMan.Uses(SomeContainer, "Use");
      contextDiagram.SomePerson.Uses(SomeContainer2, "Use");
      contextDiagram.SomeMan.Uses(SomeContainer2, "Use");
      contextDiagram.SomePerson.Uses(SomeContainer3, "Use");
      contextDiagram.SomeMan.Uses(SomeContainer3, "Use");


      // se crean las relaciones entre los contenedores con los servicios externo si se necesario
      SomeContainer.Uses(ApiRest, "API Request", "JSON HTTPS");
      SomeContainer2.Uses(ApiRest, "API Request", "JSON HTTPS");
      SomeContainer3.Uses(ApiRest, "API Request", "JSON HTTPS");

      ApiRest.Uses(contextDiagram.SomeThird, "API Request", "JSON HTTPS");
      ApiRest.Uses(contextDiagram.SomeSystem, "API Request", "JSON HTTPS");

      ContainerView containerView = c4.ViewSet.CreateContainerView(contextDiagram.SomeMain, "Containers", "Diagram Containers");
      containerView.AddAllContainers();
      containerView.AddAllPeople();
      containerView.AddAllSoftwareSystems();
    }



  }

}

