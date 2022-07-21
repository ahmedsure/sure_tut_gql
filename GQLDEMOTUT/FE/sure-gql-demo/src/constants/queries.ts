import { Injectable } from "@angular/core";
import { gql, Query } from "apollo-angular";

export interface InitUserInfoAndPostsResponse {

}


export const AllPostsGQL  =gql
  `query  userof($userId: UUID!){
    user(userId: $userId) {
    userNationality,
    userPosts{
      postedOn,
      postReactions{
        reactionTaken
      },
      postContent,
      postComments{
        commentedOn,
        commentContent
        commentComments{
          commentedOn,
          commentor {
            userName
          },
        }
      }
    },
    weatherForecast {
      temperatureC,
      summary
    },
    userName,

  }
  }
  `;

