import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private router: Router) {}

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    if (this.authService.loggedIn) {
      // Si el usuario está autenticado y trata de acceder a login o register, redirige al home
      if (state.url === '/login' || state.url === '/register') {
        this.router.navigate(['/']);
        return false;
      }
      return true; // Permite acceder a las rutas protegidas
    } else {
      // Si el usuario no está autenticado y trata de acceder a una ruta protegida, redirige al login
      if (state.url !== '/login' && state.url !== '/register') {
        this.router.navigate(['/login']);
        return false;
      }
      return true; // Permite acceder a login y register
    }
  }
}
