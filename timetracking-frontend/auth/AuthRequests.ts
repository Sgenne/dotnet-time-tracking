import axios from "axios";
import Result from "../utils/Result";
import { LOGIN_URL } from "../utils/Urls";
import LoginResponse from "../types/apiResponses/LoginResponse";

export const sendLoginRequest = async (
  username: string,
  password: string
): Promise<Result<LoginResponse>> => {
  const loginResult = await axios.post<LoginResponse>(
    LOGIN_URL,
    {
      username,
      password,
    },
    {
      headers: { "content-type": "text/json" },
    }
  );

  const result: Result<LoginResponse> = {
    status: loginResult.status,
    value: loginResult.data,
  };

  return result;
};
