import axios, { AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";
import { LOGIN_URL } from "../utils/Urls";
import LoginResponse from "../types/apiResponses/LoginResponse";

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
