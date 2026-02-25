export interface User {
  id: string;
  firstName: string;
  lastName: string;
  email: string;
  createdAt: string;
}

export interface CreateUserRequest {
  firstName: string;
  lastName: string;
  email: string;
}

export interface UpdateUserRequest {
  firstName: string;
  lastName: string;
  email: string;
}
