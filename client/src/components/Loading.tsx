import React from "react";

export const Loading: React.FC = () => {
  return (
    <div className="d-flex justify-content-center pb-5">
      <div className="spinner-grow text-primary" role="status">
        <span className="sr-only">Loading...</span>
      </div>
    </div>
  );
};
