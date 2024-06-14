using component_diagram;
using ctn_diagram;
using ctx_diagram;
using Structurizr;
using Structurizr.Api;



namespace c4_model_template
{

  public class C4
  {

    private readonly long workspaceId = ;
    private readonly string apiKey = "";
    private readonly string apiSecret = "";

    public StructurizrClient StructurizrClient { get; set; }
    public Workspace Workspace { get; set; }
    public Model Model { get; set; }
    public ViewSet ViewSet { get; set; }


    public C4() {
      string workspaceName = "C4 Model Design - PC 2 - Jonatan Acuña";
      string workspaceDescription = "";

      StructurizrClient = new StructurizrClient(apiKey, apiSecret);
      Workspace = new Workspace(workspaceName, workspaceDescription);
      Model = Workspace.Model;
      ViewSet = Workspace.Views;
    }
    public void Generate()
    {
      ContextDiagram contextDiagram = new ContextDiagram(this);
      ContainerDiagram containerDiagram = new ContainerDiagram(this, contextDiagram);

      SomeComponent someComponent = new SomeComponent(this, containerDiagram, contextDiagram);


      contextDiagram.Generate();
      containerDiagram.Generate();

      someComponent.Generate();
      

      StructurizrClient.PutWorkspace(workspaceId, Workspace);
    }

  }
}
