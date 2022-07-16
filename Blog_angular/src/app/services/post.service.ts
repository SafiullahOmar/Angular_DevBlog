import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Post } from '../models/post.model';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  
  api=environment.apiBaseURL;
  constructor(private http:HttpClient) { }

  getAllPosts():Observable<Post[]> {
   return this.http.get<Post[]>(this.api+'posts')
  }
}
