import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { routing } from './app.routing';
import { AccountModule } from './account/account.module';
import { ConfigService } from './shared/utils/config.service';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { UserPanelModule } from './user-panel/user-panel.module';
import { UserService } from './shared/services/user.service';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent
  ],
  imports: [
    UserPanelModule,
    AccountModule,
    BrowserModule,
    HttpClientModule,
    FormsModule,
    routing
  ],
  providers: [ConfigService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
