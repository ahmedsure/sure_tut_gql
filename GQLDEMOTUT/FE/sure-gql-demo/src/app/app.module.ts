import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HomeComponent } from 'src/home/home';
import { AppRoutingModule } from './app-routing.module';
import { environment } from 'src/environments/environment';
import {HttpClientModule} from '@angular/common/http';

import { FragmentDefinitionNode, OperationDefinitionNode } from 'graphql';

import {ApolloModule,APOLLO_OPTIONS} from 'apollo-angular';
import {HttpLink} from 'apollo-angular/http';
import {InMemoryCache} from '@apollo/client/core';
import {split, ApolloClientOptions } from '@apollo/client/core';
import {WebSocketLink} from '@apollo/client/link/ws';
import {getMainDefinition} from '@apollo/client/utilities';
import { PostComponent } from '../post/post.component';

@NgModule({
  imports: [
      BrowserModule,
      ReactiveFormsModule,
      HttpClientModule,
      AppRoutingModule,
      ApolloModule
  ],
  declarations: [
      AppComponent,
      HomeComponent,
      PostComponent,
  ],
  providers: [
    {
      provide: APOLLO_OPTIONS,
      useFactory(httpLink: HttpLink): ApolloClientOptions<any> {
        // Create an http link:
        const servUrl:string = environment.MainPath;
        const http = httpLink.create({
          uri: servUrl+ `graphql`
        });
        const links= servUrl.replace('http','ws').replace('https','wss') + `graphql`;
        // Create a WebSocket link:
        const ws = new WebSocketLink({
          uri:  links,
          options: {
            reconnect: true,
          },
        });
        // using the ability to split links, you can send data to each link
        // depending on what kind of operation is being sent
        console.log('Environment Is :',environment.production);
        const link = split(
          // split based on operation type
          ({query}) => {
            const  ret: OperationDefinitionNode|FragmentDefinitionNode = getMainDefinition(query);
            return (
              ret.kind === 'OperationDefinition' && ret.operation === 'subscription'
            );
          },
          ws,
          http,
        );

        return {
          link,
          cache: new InMemoryCache(),
          // ... options
        };
      },
      deps: [HttpLink],
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { };
