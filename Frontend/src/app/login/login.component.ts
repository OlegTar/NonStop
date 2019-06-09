import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private cookie: CookieService) { }

  ngOnInit() {
  }

  loginVk() {
    let sessionId = '';
    const abc = 'abcdefghijklmnoprqstuvwxyz01234569'.split('');
    for (let i = 0; i < 50; i++) {
      const char = abc[Math.floor(Math.random() * abc.length)];
      sessionId += char;
    }

    const d = new Date();
    d.setTime(d.getTime() + 3600000);
    this.cookie.set('sessionId', sessionId, d);
    // localStorage.setItem('setItem', sessionId);
    const redirectUri = window.location.href.replace(/^(https?:\/\/)(.*?)\/.*$/, '$1$2');

    console.log('https://localhost:44314/Home/Login?redirectUri=' +
    encodeURIComponent(redirectUri) + '&sessionId=' + encodeURIComponent(sessionId));

    window.location.href = 'https://localhost:44314/Home/Login?redirectUri=' +
    encodeURIComponent(redirectUri) + '&sessionId=' + encodeURIComponent(sessionId);

    // const img = new Image();
    // img.src = 'https://localhost:44314/Home/Login?redirectUri=' +
    // encodeURIComponent(redirectUri) + '&sessionId=' + encodeURIComponent(sessionId);

    // this.router.navigateByUrl('https://localhost:44314/Home/Login?redirectUri=' +
    // encodeURIComponent(redirectUri) + '&sessionId=' + encodeURIComponent(sessionId));
  }
}
