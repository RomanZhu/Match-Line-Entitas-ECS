public class ComboDetectionSystems : Feature
{
    //Those systems ignore InCombo and not InMatch entities
    //When system detects some entities are in pattern, then it sets InCombo component on them
    
    //This means the order should be from bigger to smaller rewards 
    public ComboDetectionSystems(Contexts contexts, Services services)
    {
        //Add(new SUPERawesomeComboSystem();
        
        Add(new Line5ComboSystem(contexts));
        
        //Add(new mehComboSystem();
    }
}