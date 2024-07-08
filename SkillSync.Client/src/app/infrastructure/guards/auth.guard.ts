import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { toRoleType } from '../../shared/utils';

export const authGuard: CanActivateFn = (route, state) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);

  const role = toRoleType(tokenService.getRole());

  if (role == null) {
    router.navigate(['/choose-login-provider']);
    return false;
  }

  return true;
};
