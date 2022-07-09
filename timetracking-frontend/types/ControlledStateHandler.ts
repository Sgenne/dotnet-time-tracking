export default interface ControlledStateHandler<T> {
  value: T;
  changeHandler: (t: T) => void;
}
