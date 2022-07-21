import { Component, Input, OnInit } from '@angular/core';
import { UserPosts } from '../home/home';



@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: [`./post.component.css`]
})
export class PostComponent implements OnInit{
  ngOnInit(): void {
    this.since =  new Date( (this.post?.postedOn ?? new Date().toISOString())).toLocaleString()
  }
  @Input() post?: UserPosts;

  since = '';

}
