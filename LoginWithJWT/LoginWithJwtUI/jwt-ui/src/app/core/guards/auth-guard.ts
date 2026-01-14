import { CanActivateFn } from '@angular/router';
import { Auth } from '../services/auth';
import { inject } from '@angular/core';


export const authGuard: CanActivateFn = (route, state) => {
  return inject(Auth).isLoggedIn();
};
