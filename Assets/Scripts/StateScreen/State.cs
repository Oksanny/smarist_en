using UnityEngine;
using System.Collections;
internal abstract class State
{
    internal virtual void HandleMark(ManagerSateScreen mangerSateScreen, Mark mark)
    { ChangeState(mangerSateScreen, mark); }
    protected  void ChangeState(ManagerSateScreen managerSateScreen, Mark mark)
    {
        switch (mark)
        {
            case Mark.main_menu:
                {
                    managerSateScreen.State = new State_main_menu();
                    break;
                }
            case Mark.ar_camera:
                {
                    managerSateScreen.State = new State_ar_camera();
                    break;
                }
            case Mark.list_letters:
                {
                    managerSateScreen.State = new State_list_letters();

                    break;
                }
            case Mark.prev_image_for_print:
                {
                    managerSateScreen.State = new State_prev_image_for_print();
                    break;
                }
            case Mark.overlay_buy:
                {
                    managerSateScreen.State = new State_overlay_buy();

                    break;
                }
            case Mark.settings:
                {
                    managerSateScreen.State = new State_settings();

                    break;
                }
            case Mark.state_screen_shot:
                {
                    managerSateScreen.State = new StateScreenShot();

                    break;
                }
            case Mark.letter:
                {
                    managerSateScreen.State = new State_letter();

                    break;
                }
            case Mark.game:
                {
                    managerSateScreen.State = new State_game();

                    break;
                }
            case Mark.state_photo:
                {
                    managerSateScreen.State = new StateCreatePhoto();

                    break;
                }
            case Mark.inf_mainmenu:
                {
                    managerSateScreen.State = new State_Inf_main_menu();

                    break;
                }
            case Mark.inf_list_letter:
                {
                    managerSateScreen.State = new State_Inf_List_Letter();

                    break;
                }
            case Mark.inf_prev_image:
                {
                    managerSateScreen.State = new State_Inf_Prev_Image();

                    break;
                }
            case Mark.inf_ar_camera:
                {
                    managerSateScreen.State = new State_Inf_AR_Camera();

                    break;
                }
            case Mark.inf_photo:
                {
                    managerSateScreen.State = new State_Inf_Photo();

                    break;
                }
		case Mark.finished_write_letter:
			{
				managerSateScreen.State = new StateFinishedWriteLetter ();

				break;
			}
        }
    }
    
}

