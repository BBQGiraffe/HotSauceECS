# HotSauceECS
simple data-oriented ECS, used in my personal game engine

## example code:

'''

   class TestComponent : Component{
          public string str = "big floppa";
          public void Start(){
              Console.WriteLine("Starting OwO");
          }

          public void MyUpdateFunc(){

          }
      }

      class TestEntity : Entity{
          public void Start(){
              var component = AddComponent<TestComponent>();
              component.str = "Bingus";
          }
      }

      class MainClass
      {
          public static void Main(string[] args)
          {
              Entity.Create<TestEntity>();
              Entity.InvokeAll("MyUpdateFunc");

          }
      }
  }
  
  '''
