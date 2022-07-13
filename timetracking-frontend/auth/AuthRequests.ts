import axios, { AxiosError, AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";
import { LOGIN_URL } from "../utils/Urls";
import LoginResponse from "../types/apiResponses/LoginResponse";
import { getErrorMessage, getErrorStatusCode } from "../utils/ErrorHandling";

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
