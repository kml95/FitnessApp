import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ModuleWithProviders } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { Routing } from './app.routing';
import { AccountModule } from './account/account.module';
import { ConfigService } from './shared/utils/config.service';
import { TransparentHeaderComponent } from './transparent-header/transparent-header.component';
import { HomeComponent } from './home/home.component';
import { FormsModule } from '@angular/forms';
import { UserService } from './shared/services/user.service';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    TransparentHeaderComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    Routing,
    AccountModule,
    // UserPanelModule,
  ],
  providers: [ConfigService, UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
