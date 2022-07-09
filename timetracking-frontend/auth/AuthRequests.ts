import axios from "axios";
import Result from "../utils/Result";
import { LOGIN_URL } from "../utils/Urls";
import { AccessToken } from "../types/AccessToken";

export const Login = async (
  username: string,
  password: string
): Promise<Result<AccessToken>> => {
  // TODO: change response type after adding "Responses" to backend.
  const loginResult = await axios.post(LOGIN_URL, {
    username,
    password,
  });

  if (loginResult.status !== 200) {
  }

  return loginResult.data;
};
