import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TokenInterface } from '../TokenInterface';
import { AuthService } from '../auth.service';
import { SessionService } from '../session.service';
@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {
  public myForm: FormGroup;
  error = false;
  model: LoginDto = { email: 'dj-m2x@hotmail.com', password: '12345678*'};

  constructor(private signinService: AuthService, public session: SessionService, private fb: FormBuilder, public router: Router) {
  }

  ngOnInit() {
    this.myForm = this.fb.group({
      email: [this.model.email, Validators.required],
      password: [this.model.password, Validators.required]
    });
  }

  doSignIn(chefForm: FormGroup) {
    this.signinService.authenticate(chefForm.value as LoginDto)
      .subscribe(
        (response: TokenInterface ) => {
          console.log(response);
          this.session.doSignIn(response.token, response.user);
          this.error = false;
          this.router.navigate(['/catalogues/all']);
        },
        (e) => {
          this.error = true;
          console.error('error = ' + e);
        }
      );
  }
}

interface LoginDto {
  email: string;
  password: string;
}


