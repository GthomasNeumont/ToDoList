using FubuMVC.Core;
using FubuMVC.StructureMap;
using StructureMap;

namespace ToDoListFinal
{
	public class ToDoListFinalApplication : IApplicationSource
	{
	    public FubuApplication BuildApplication()
	    {
            return FubuApplication.For<ToDoListFinalFubuRegistry>()
				.StructureMap<ToDoListFinalRegistry>();
	    }
	}
}