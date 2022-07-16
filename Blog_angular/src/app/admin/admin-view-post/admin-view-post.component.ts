import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Post } from 'src/app/models/post.model';
import { updatePostRequest } from 'src/app/models/update-post.model';
import { PostService } from 'src/app/services/post.service';

@Component({
  selector: 'app-admin-view-post',
  templateUrl: './admin-view-post.component.html',
  styleUrls: ['./admin-view-post.component.css']
})
export class AdminViewPostComponent implements OnInit {

  constructor(private route: ActivatedRoute, private service: PostService) { }

  post: Post | undefined;
  ngOnInit(): void {
    this.route.paramMap.subscribe(result => {
      const id = result.get('id');
      if (id) {
        this.service.getPostById(id).subscribe(Response => {
          this.post = Response;
        });
      }
    });
  }

  onsubmit():void{
    const updatePostRequest:updatePostRequest={
      Author:this.post?.Author,
      Content:this.post?.Content,
      FeautredImageURL:this.post?.FeautredImageURL,
      PublishDate:this.post?.PublishDate,
      UpdateDate:this.post?.UpdateDate,
      Visible:this.post?.Visible,
      Summary:this.post?.Summary,
      Title:this.post?.Title,
      URLHandle:this.post?.URLHandle,
    }
    this.service.updatePost(this.post?.Id,updatePostRequest).subscribe(result=>{
      alert('updated');
    });

  }

}
