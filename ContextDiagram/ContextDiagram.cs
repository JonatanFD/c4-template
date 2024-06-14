using c4_model_template;
using Structurizr;


namespace ctx_diagram
{
  public class ContextDiagram
  {

    private readonly C4 c4;

    // Se coloca los person o lo que interactuan con el sistema
    public Person SomePerson { get; private set; }
    public Person SomeMan { get; private set; }


    // Los sistemas que interactuan
    public SoftwareSystem SomeMain { get; private set; }
    public SoftwareSystem SomeSystem { get; private set; }
    public SoftwareSystem SomeThird { get; private set; }

    public ContextDiagram(C4 c4)
    {
      this.c4 = c4;
    }

    public void Generate() {
      // Se generan los elementos del sistema como la persona y los sistemas con los que interactua
      // (name, description)
      SomePerson = c4.Model.AddPerson("Some Person", "Some person that interacts with the system");
      SomeMan = c4.Model.AddPerson("Some Man", "Some description");

      SomeMain = c4.Model.AddSoftwareSystem("Some Main", "Some description");
      SomeSystem = c4.Model.AddSoftwareSystem("Some System", "Some description");
      SomeThird = c4.Model.AddSoftwareSystem("Some Third", "Some description");

      // Se crean las relaciones entre los elementos
      SomePerson.Uses(SomeMain, "Por que usa el sistema?");
      SomeMan.Uses(SomeMain, "Por que usa el sistema?");

      SomeMain.Uses(SomeSystem, "Por que usa el sistema?");
      SomeMain.Uses(SomeThird, "Por que usa el sistema?");
      

      SystemContextView contextView = c4.ViewSet.CreateSystemContextView(SomeMain, "Context", "Diagram Context");
      contextView.AddAllPeople();
      contextView.AddAllSoftwareSystems();
    }


  }


}