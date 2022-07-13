import { AxiosError } from "axios";

export const getErrorMessage = (e: any): string =>
  getErrorResponseContent<string>(
    e,
    (e) => (e.response ? e.response.data : "Something went wrong..."),
    "Something went wrong..."
  );

export const getErrorStatusCode = (e: any): number =>
  getErrorResponseContent<number>(
    e,
    (e) => (e.response ? e.response.status : 500),
    500
  );

const getErrorResponseContent = <T>(
  error: any,
  filter: (e: AxiosError<any, T>) => T,
  defaultValue: T
) => {
  if (!(error instanceof AxiosError) || !error.response) return defaultValue;

  return filter(error);
};
