import { Injectable } from "@angular/core";



@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  currentUserValue: any = undefined;

  /**
   *
   */
  constructor() {
    this.currentUserValue = localStorage.getItem("userid")
  }
  setUser(id:string)
  {
    localStorage.setItem("userid",id)
  }


}
