using TodoList.Models;
using System.Linq;
using System.Web;
using System.Web.UI;
using FubuMVC.Core.Continuations;
using ToDoListFinal.Endpoints;
using FubuMVC.Core.Ajax;
using System;

namespace ToDoListFinal
{

	public class HomeEndpoint
	{
        HomeModel HM = HomeModel.Instance();
      
        public HomeModel Index()
        {
            return HM;
        }

        public AjaxContinuation post_add_ToList(NewGiosInputModel input)
        {
            Task T = new Task(input.MyTitle,input.Description,false);
            HM.TNDM.AddToTasks(T);

            var continuation = AjaxContinuation.Successful();
            continuation["newlyAddedTask"] = T;

            return continuation;
        }

        public AjaxContinuation post_remove_FromList(NewToRemoveInputModel input)
        {
            HM.TNDM.RemoveFromTasks(input.ID);

            var continuation = AjaxContinuation.Successful();

            return continuation;
        }

        public AjaxContinuation post_edit_Item(NewToRemoveInputModel input)
        {
            var continuation = AjaxContinuation.Successful();
            return continuation;
        }

	}
}