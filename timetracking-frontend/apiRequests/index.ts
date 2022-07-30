import axios, { AxiosResponse } from "axios";
import Result, { resultFromAxiosError } from "../utils/Result";

export const baseUrl = "http://localhost:8080";

interface RequestArgs {
  url: string;
  data: object;
  config?: Config;
  successMessage?: string;
  accessToken?: string;
}

type Config = { headers: object } & { [key: string]: any };

type AxiosRequest<TApiResponse> = (
  url: string,
  data: object,
  config: object
) => Promise<AxiosResponse<TApiResponse>>;

export const sendGetRequest = async <TApiResponse>(
  args: RequestArgs
): Promise<Result<TApiResponse>> => sendRequest(args, axios.get);

export const sendPostRequest = async <TApiResponse>(
  args: RequestArgs
): Promise<Result<TApiResponse>> => sendRequest<TApiResponse>(args, axios.post);

const sendRequest = async <TApiResponse>(
  {
    config = {
      headers: { "content-type": "text/json" },
    },
    url,
    data,
    successMessage = "",
    accessToken = "",
  }: RequestArgs,
  requestFunction: AxiosRequest<TApiResponse>
): Promise<Result<TApiResponse>> => {
  let result: AxiosResponse<TApiResponse>;
  try {
    result = await requestFunction(
      url,
      data,
      accessToken
        ? {
            ...config,
            headers: {
              ...config.headers,
              Authorization: `Bearer ${accessToken}`,
            },
          }
        : config
    );
  } catch (error) {
    return resultFromAxiosError(error);
  }

  return {
    value: result.data,
    status: result.status,
    message: successMessage,
  };
};
