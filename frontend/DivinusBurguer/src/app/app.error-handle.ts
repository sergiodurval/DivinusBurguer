import { ErrorHandler , Injectable , NgZone } from '@angular/core'
import { HttpErrorResponse} from '@angular/common/http'
import { Observable } from 'rxjs/Observable'
import 'rxjs/add/Observable/throw'
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';

@Injectable()
export class ApplicationErrorHandler extends ErrorHandler{
    
    constructor(private toastyService:ToastyService,private toastyConfig: ToastyConfig, private zone:NgZone )
    {
       super()
    }

    handleError(errorResponse: HttpErrorResponse | any){
      if(errorResponse instanceof HttpErrorResponse){
        this.zone.run(() =>{
            if(errorResponse.status == 400){
               this.addToast(this.getErrorMessage(errorResponse))
            }else{
                this.addToast(errorResponse.message)
            }
            
        })
        
      }
      
    }

    
    getErrorMessage(errorResponse:HttpErrorResponse):string{
        let messageArray = errorResponse.error.errors
        let msgErro = undefined

        for(let i = 0 ; i < messageArray.length ; i++){
            msgErro = messageArray[i].message
        }
        return msgErro
    }

    addToast(mensagem) {
        var toastOptions:ToastOptions = {
            title: 'aviso',
            msg: mensagem,
            showClose: true,
            timeout: 2000,
            theme: 'bootstrap',
            onAdd: (toast:ToastData) => {
              //console.log('Toast ' + toast.id + ' has been added!');
          },
          onRemove: function(toast:ToastData) {
              //console.log('Toast ' + toast.id + ' has been removed!');
          }
        };
        
        this.toastyService.error(toastOptions);
      }
}