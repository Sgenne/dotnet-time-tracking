export default interface ControlledStateHandler<T> {
  value: T;
  onChange: (t: T) => void;
  onBlur: () => void;
  hasError: boolean;
  errorMessage?: string;
}
