import axios, { AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";
import LoginResponse from "../types/apiResponses/LoginResponse";
import { baseUrl } from ".";

const baseAuthUrl = `${baseUrl}/auth`;

export const LOGIN_URL = `${baseAuthUrl}/login`;
export const REGISTER_URL = `${baseAuthUrl}/register`;

/**
 * Sends a login request to the backend API. If successful, then an access token
 * that can be used to identify the signed in user in subsequent requests is
 * returned.
 */
export const sendLoginRequest = async (
  username: string,
  password: string
): Promise<Result<LoginResponse>> => {
  let loginResult: AxiosResponse<LoginResponse>;
  try {
    loginResult = await axios.post<LoginResponse>(
      LOGIN_URL,
      {
        username,
        password,
      },
      {
        headers: { "content-type": "text/json" },
      }
    );
  } catch (error) {
    return resultFromAxiosError(error);
  }

  return {
    value: loginResult.data,
    status: loginResult.status,
    message: "Logged in successfully.",
  };
};
