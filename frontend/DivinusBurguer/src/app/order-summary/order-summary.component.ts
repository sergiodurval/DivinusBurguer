import { Component, OnInit } from '@angular/core';
import { User } from 'app/login/user.model';
import { Router, NavigationEnd , ActivatedRoute } from '@angular/router';
import { AuthenticationService } from 'app/login/authentication.service';


@Component({
  selector: 'app-order-summary',
  templateUrl: './order-summary.component.html',
  styleUrls: ['./order-summary.component.css']
})
export class OrderSummaryComponent implements OnInit {
  isLogged : boolean
  user: User
  numeroPedido:string

  constructor(private authenticationService: AuthenticationService,
    private router: Router,
    private activatedRoute:ActivatedRoute) {
      this.router.events.subscribe((e) => {
        if (e instanceof NavigationEnd) {
            if(this.authenticationService.isLoggedIn()){
              this.user = this.authenticationService.getUser()
            }
        }
     });
    }

  ngOnInit() {
    if(this.user != undefined){
      this.isLogged = true
    }
    this.numeroPedido = this.activatedRoute.snapshot.paramMap.get('numeroPedido')
    
  }

}
