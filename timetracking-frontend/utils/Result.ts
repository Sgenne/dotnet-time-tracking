import StatusCode from "./StatusCodes";

export default interface Result<T> {
  status: StatusCode;
  message: string;
  value?: T;
}
