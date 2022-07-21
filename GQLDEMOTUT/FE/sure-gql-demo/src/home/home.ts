import { Component, OnInit } from '@angular/core';
import {Apollo, Subscription} from 'apollo-angular';
import { AuthenticationService } from '../helpers/AuthenticationService';
import { AllPostsGQL } from '../constants/queries';
import { catchError, map } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.html'
})
export class HomeComponent implements OnInit {

  constructor(private apollo: Apollo, private authed: AuthenticationService, private httpclient: HttpClient) {

  }
  userInitDataAndPosts: UserReturnedData|undefined = {};
  ngOnInit() {
    this.httpclient.get(environment.MainPath + 'Testing').pipe(map((res) => {
      console.log(res);
    })).subscribe((res) => { });
    if (this.authed.currentUserValue && this.authed.currentUserValue.length > 0) {
       this.apollo.query<QueryRes>({
        query : AllPostsGQL,
        variables: {
          userId: this.authed.currentUserValue,
        }
      })
        .pipe(
          map(result => {
            console.log(result);
            this.userInitDataAndPosts = result.data.user ;
            return result.data
          })
        )
        .pipe(catchError((err) => {
          console.log(err);
          return err;
        }))
        .subscribe();

    }
  }
}

export class UserPosts{
  postedOn? : Date;
  postReactions?:any[];
  postContent?: string;
  postComments?: any[];
}
export class WeatheForecast{
  temperatureC?: number;
  summary?: string;
}
export class UserReturnedData{
    userNationality?: string;
    userPosts?: UserPosts[];
    weatherForecast? : WeatheForecast;
    userName?:string;
}
export class QueryRes {
    user?:UserReturnedData;
}

