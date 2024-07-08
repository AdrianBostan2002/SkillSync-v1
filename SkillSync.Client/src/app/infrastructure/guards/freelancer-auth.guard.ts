import { CanActivateFn, Router } from '@angular/router';
import { TokenService } from '../../services/token.service';
import { inject } from '@angular/core';
import { toRoleType } from '../../shared/utils';
import { RoleType } from '../../shared/enums/role-type';

export const freelancerAuthGuard: CanActivateFn = (next, state) => {
  const tokenService = inject(TokenService);
  const router = inject(Router);

  const role = toRoleType(tokenService.getRole());

  if (role !== RoleType.Freelancer) {
    router.navigate(['/choose-login-provider']);
    return false;
  }

  return true;
};
