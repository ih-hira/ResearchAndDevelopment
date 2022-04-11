import { Component, OnDestroy, OnInit } from '@angular/core';
import { UserDetailsService } from '../services/user-details.service';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { UserDetails } from '../view-model/user-details.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css'],
  providers: [UserDetailsService]
})
export class ProfileComponent implements OnInit, OnDestroy {

  public userDetails: UserDetails;
  private userName: string = '';
  private subscription: Subscription = new Subscription;
  constructor(private userDetailsService: UserDetailsService, private activatedroute: ActivatedRoute) {
  }

  ngOnInit(): void {
    this.activatedroute.paramMap.subscribe(params => {
      this.userName = params.get('username') as string;
      this.subscription = this.userDetailsService.getUserByUserName(this.userName).subscribe(
        (result: UserDetails) => {
          this.userDetails = result;
          console.log(result);
        });

    });

  }
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

}
