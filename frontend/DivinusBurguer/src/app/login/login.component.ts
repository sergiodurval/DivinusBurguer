import { Component, OnInit } from '@angular/core';
import { User } from './user.model';
import { AuthenticationService } from './authentication.service';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  user : User

  constructor(private authenticationService:AuthenticationService , private router : Router) {
     this.user = new User()
   }

  ngOnInit() {
  }


  login():void{
    this.authenticationService.login(this.user)
    .subscribe(data => {
       this.user = data
       if(this.user.id != undefined){
          this.authenticationService.getToken()
          .subscribe(t => {
            this.user.token = t.access_token
            this.router.navigate(['/cardapio'])
          })
       }
    });
      
     

  }

}
