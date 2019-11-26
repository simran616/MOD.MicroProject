import { Component, OnInit } from '@angular/core';
import { ProfileService } from '../profile.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-payment-page',
  templateUrl: './payment-page.component.html',
  styleUrls: ['./payment-page.component.scss']
})
export class PaymentPageComponent implements OnInit {

  constructor(private _profileservice : ProfileService,
            private _router: Router,
            private _route :ActivatedRoute) { }
    id:any
  ngOnInit() {
    this.id = parseInt(this._route.snapshot.paramMap.get('id'));
  }

  PayNow(id){
    this._profileservice.paynow(id)
    .subscribe(
      res=>{
        console.log(res)
        this._router.navigateByUrl('student-enrolled-courses')

      },
      err=> console.log(err)
    )
    
  }

}
