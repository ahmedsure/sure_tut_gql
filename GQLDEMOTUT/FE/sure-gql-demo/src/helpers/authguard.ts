import { Router } from './../../node_modules/@types/express-serve-static-core/index.d';
import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot } from "@angular/router";
import { AuthenticationService } from './AuthenticationService';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private authenticationService: AuthenticationService
    ) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authenticationService.currentUserValue;
        if (currentUser) {
            // authorised so return true
            return true;
        }

        // not logged in so redirect to login page with the return url
        let sign = prompt("What's your sign ID ?");
        if(sign&& sign.length > 1){
          debugger
          this.authenticationService.setUser(sign);
          return true;
        }
        return false;
    }
}
