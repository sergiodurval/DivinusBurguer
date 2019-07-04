import { Component, OnInit } from '@angular/core';
import { User } from 'app/login/user.model';
import { AuthenticationService } from 'app/login/authentication.service';
import { ToastyService, ToastyConfig, ToastOptions, ToastData } from 'ng2-toasty';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  
  user : User

  constructor(private authenticationService:AuthenticationService,
              private toastyService:ToastyService,
              private toastyConfig: ToastyConfig,
              private router : Router) {
              this.user = new User()
   }

  ngOnInit() {
  }
  
   registrar(){
     this.authenticationService.register(this.user)
     .subscribe(data => {
         this.addToast(`${this.user.email} cadastrado com sucesso`)
         this.router.navigate(['/home'])
     });
     
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
    
    this.toastyService.success(toastOptions);
  }
}
