import { AccessToken } from "../AccessToken";
import ApiResponse from "./ApiResponse";

export default interface LoginResponse extends ApiResponse {
  accessToken: AccessToken;
}
