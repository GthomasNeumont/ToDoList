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
            if (HM.TNDM.checkIfInDictionary(input.ID))
            {
                HM.TNDM.RemoveFromTasks(input.ID);
            }
            else
            {
                HM.TDM.RemoveFromTasks(input.ID);
            }

            var continuation = AjaxContinuation.Successful();

            return continuation;
        }

        public AjaxContinuation post_Task_Info(NewEditInputModel input)
        {
            Task T = new Task(input.MyTitle,input.Description,false);
            if (HM.TNDM.checkIfInDictionary(input.ID))
            {
                T = HM.TNDM.getTask(input.ID);
            }
            else
            {
                T = HM.TDM.getTask(input.ID);
            }

            var continuation = AjaxContinuation.Successful();
            continuation["newlyAddedTask"] = T;

            return continuation;
        }

        public AjaxContinuation post_Edit_Task(NewEditInputModel input)
        {
            Task T = new Task(input.MyTitle, input.Description, false);

                if (HM.TNDM.checkIfInDictionary(input.ID))
                {
                    T.ID = input.ID;

                    HM.TNDM.updateTask(input.ID, T);
                    T = HM.TNDM.getTask(input.ID);
                }
                else
                {
                    T.ID = input.ID;

                    HM.TDM.updateTask(input.ID, T);
                    T = HM.TDM.getTask(input.ID);
                }
                
            
            var continuation = AjaxContinuation.Successful();
            continuation["newlyAddedTask"] = T;

            return continuation;
            

        }

        public AjaxContinuation post_move_Item(NewMoveInputModel input)
        {
            Task T = null;

            if (HM.TNDM.checkIfInDictionary(input.ID))
            {
                HM.TDM.AddToTasks(HM.TNDM.getTask(input.ID));
                T = HM.TNDM.getTask(input.ID);
                T.isComplete = true;
                HM.TNDM.RemoveFromTasks(input.ID);
            }
            else
            {
                HM.TNDM.AddToTasks(HM.TDM.getTask(input.ID));
                T = HM.TDM.getTask(input.ID);
                T.isComplete = false;
                HM.TDM.RemoveFromTasks(input.ID);
            }

            var continuation = AjaxContinuation.Successful();
            continuation["newlyAddedTask"] = T;
            return continuation;
        }

	}
}